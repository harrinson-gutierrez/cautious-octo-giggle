using Application.DTOs.Roulettes;
using Application.Interfaces.Mapping;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Roulettes.Queries.GetAllRoulette
{
    public class GetAllRouletteQuery : IRequest<Response<List<RouletteModel>>>
    {
    }

    public class GetAllRouletteQueryHandler : IRequestHandler<GetAllRouletteQuery, Response<List<RouletteModel>>>
    {
        private readonly IRouletteRepository RouletteRepository;
        private readonly IRouletteMapper RouletteMapper;

        public GetAllRouletteQueryHandler(IRouletteRepository rouletteRepository, IRouletteMapper rouletteMapper)
        {
            RouletteRepository = rouletteRepository;
            RouletteMapper = rouletteMapper;
        }

        public async Task<Response<List<RouletteModel>>> Handle(GetAllRouletteQuery request, CancellationToken cancellationToken)
        {
            var getAll = await RouletteRepository.GetAllAsync();

            return Response<List<RouletteModel>>.Ok(RouletteMapper.Convert(getAll));
        }
    }
}
