using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Repositories
{
    public class RouletteRepository : RepositoryPostgresql<int, Roulette>, IRouletteRepository
    {
        public RouletteRepository(IConfiguration configuration) : base(configuration) { }
    }
}
