using Application.DTOs.Roulettes;
using Application.Enums;
using Application.Interfaces.Mapping;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Roulettes.Commands.CreateRoulette
{
    public class CreateRouletteCommand : IRequest<Response<RouletteModel>>
    {
    }

    public class CreateRouletteCommandHandler : IRequestHandler<CreateRouletteCommand, Response<RouletteModel>>
    {
        private readonly IRouletteRepository RouletteRepository;
        private readonly IRouletteMapper RouletteMapper;

        public CreateRouletteCommandHandler(IRouletteRepository rouletteRepository, IRouletteMapper rouletteMapper)
        {
            RouletteRepository = rouletteRepository;
            RouletteMapper = rouletteMapper;
        }

        public  async Task<Response<RouletteModel>> Handle(CreateRouletteCommand request, CancellationToken cancellationToken)
        {
            var entity = new Roulette
            {
                state = RouletteState.CLOSED.ConvertToString()
        };

            var savedId = await RouletteRepository.CreateAsync(entity);

            entity.id = savedId;

            return Response<RouletteModel>.Ok(RouletteMapper.Convert(entity));
        }
    }
}
