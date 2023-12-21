using Application.DTOs.Roulettes;
using Application.Enums;
using Application.Exceptions;
using Application.Interfaces.Mapping;
using Application.Interfaces.Repositories;
using Application.Interfaces.Resources;
using Application.Util;
using Application.Wrappers;
using Domain.Entities;
using Domain.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Roulettes.Commands.CloseRoulette
{
    public class CloseRouletteCommand : IRequest<Response<RouletteModel>>
    {
        public Guid Id { get; set; }
    }

    public class CloseRouletteCommandHandler : IRequestHandler<CloseRouletteCommand, Response<RouletteModel>>
    {
        private readonly IRouletteRepository RouletteRepository;
        private readonly IBetRouletteRepository BetRouletteRepository;
        private readonly IRouletteMapper RouletteMapper;
        private readonly IBetRouletteMapper BetRouletteMapper;
        private readonly IAppResource AppResource;
        private readonly IOptions<RouletteOptions> CustomJwtOptions;

        public CloseRouletteCommandHandler(IRouletteRepository rouletteRepository,
                                            IBetRouletteRepository betRouletteRepository,
                                           IRouletteMapper rouletteMapper,
                                           IBetRouletteMapper betRouletteMapper,
                                           IAppResource appResource,
                                           IOptions<RouletteOptions> customJwtOptions)
        {
            RouletteRepository = rouletteRepository;
            RouletteMapper = rouletteMapper;
            AppResource = appResource;
            BetRouletteRepository = betRouletteRepository;
            BetRouletteMapper = betRouletteMapper;
            CustomJwtOptions = customJwtOptions;
        }

        public async Task<Response<RouletteModel>> Handle(CloseRouletteCommand request, CancellationToken cancellationToken)
        {
            var entity = await RouletteRepository.GetByIdAsync(request.Id);

            if (entity == null) throw new NotFoundException(AppResource["Roulette-Not-Found"]);

            if (entity.state != RouletteState.OPEN.ConvertToString()) throw new ApiException(AppResource["Roulette-Has-Not-Open"]);

            int winnerRandom = RandomUtil.RangeNumber(0, 36);

            var bets = await BetRouletteRepository.GetAllWithQuery("WHERE roulette_id=@id AND deleted_at IS NULL", new { entity.id });
            ProcessBetsRoulette(bets, winnerRandom);

            try
            {
                await BetRouletteRepository.UpdateAllAsync(bets);
                entity.state = RouletteState.CLOSED.ConvertToString();
                await RouletteRepository.UpdateAsync(entity);   
            }
            catch (Exception e)
            {
                throw new ApiException(AppResource["Roulette-cannot-close"], new { Error = e.Message});
            }

            var response = RouletteMapper.Convert(entity);
            response.Bets = BetRouletteMapper.Convert(bets);

            return Response<RouletteModel>.Ok(response);
        }

        private void ProcessBetsRoulette(List<BetRoulette> bets, int winnerRandom)
        {
            bets.ForEach(bet =>
            {
                if (bet.number == winnerRandom)
                {
                    bet.winner = true;
                    bet.earned_bet = bet.bet * decimal.Parse(CustomJwtOptions.Value.EarnedWinnerNumber);
                }
                else if (bet.color == RouletteColorExtension.GetRouletteColor(winnerRandom).ConvertToString())
                {
                    bet.winner = true;
                    bet.earned_bet = bet.bet * decimal.Parse(CustomJwtOptions.Value.EarnedWinnerColor);
                }
                else
                {
                    bet.winner = false;
                }

                bet.deleted_at = DateTime.Now;
            });
        }
    }
}
