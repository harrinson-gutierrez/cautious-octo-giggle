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

namespace Application.Features.Roulettes.Commands.OpenRoulette
{
    public class OpenRouletteCommand : IRequest<Response<RouletteModel>>
    {
        public Guid Id { get; set; }
    }

    public class OpenRouletteCommandHandler : IRequestHandler<OpenRouletteCommand, Response<RouletteModel>>
    {
        private readonly IRouletteRepository RouletteRepository;
        private readonly IRouletteMapper RouletteMapper;
        private readonly IAppResource AppResource;

        public OpenRouletteCommandHandler(IRouletteRepository rouletteRepository,
            IRouletteMapper rouletteMapper, IAppResource appResource)
        {
            RouletteRepository = rouletteRepository;
            RouletteMapper = rouletteMapper;
            AppResource = appResource;
        }

        public async Task<Response<RouletteModel>> Handle(OpenRouletteCommand request, CancellationToken cancellationToken)
        {

            var entity = await RouletteRepository.GetByIdAsync(request.Id);

            if (entity == null) throw new NotFoundException(AppResource["Roulette-Not-Found"]);

            if (entity.state == RouletteState.OPEN.ConvertToString()) throw new ApiException(AppResource["Roulette-Has-Open"]);

            entity.state = RouletteState.OPEN.ConvertToString();

            await RouletteRepository.UpdateAsync(entity);

            return Response<RouletteModel>.Ok(RouletteMapper.Convert(entity));
        }
    }
}
