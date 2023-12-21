using Application.DTOs.Roulette;
using Application.DTOs.Roulettes;
using Application.Enums;
using Application.Exceptions;
using Application.Interfaces.Mapping;
using Application.Interfaces.Repositories;
using Application.Interfaces.Resources;
using Application.Wrappers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Roulettes.Commands.BetRoulette
{

    public class BetRouletteCommand : IRequest<Response<BetRouletteModel>>
    {
        public int UserId { get; set; }
        public Guid RouletteId { get; set; }
        public decimal Bet { get; set; }
        public int Number { get; set; }
    }

    public class BetRouletteCommandHandler : IRequestHandler<BetRouletteCommand, Response<BetRouletteModel>>
    {
        private readonly IRouletteRepository RouletteRepository;
        private readonly IBetRouletteMapper BetRouletteMapper;
        private readonly IBetRouletteRepository BetRouletteRepository;
        private readonly IAppResource AppResource;

        public BetRouletteCommandHandler(IRouletteRepository rouletteRepository,
                                        IBetRouletteMapper betRouletteMapper,
                                        IBetRouletteRepository betRouletteRepository,
                                        IAppResource appResource)
        {
            RouletteRepository = rouletteRepository;
            BetRouletteRepository = betRouletteRepository;
            AppResource = appResource;
            BetRouletteMapper = betRouletteMapper;
        }

        public async Task<Response<BetRouletteModel>> Handle(BetRouletteCommand request, CancellationToken cancellationToken)
        {
            var roulette = await RouletteRepository.GetByIdAsync(request.RouletteId);

            if (roulette == null) throw new NotFoundException(AppResource["Roulette-Not-Found"]);

            if (roulette.State != RouletteState.OPEN.ConvertToString()) throw new ApiException(AppResource["Roulette-Has-Not-Open"]);

            var betRoulette = BetRouletteMapper.ConvertEntity(request);

            await BetRouletteRepository.CreateAsync(betRoulette);

            return Response<BetRouletteModel>.Ok(BetRouletteMapper.Convert(betRoulette));
        }
    }
}
