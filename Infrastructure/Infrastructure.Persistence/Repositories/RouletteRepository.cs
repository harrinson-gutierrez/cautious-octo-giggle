using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;

namespace Infrastructure.Persistence.Repositories
{
    public class RouletteRepository : RepositoryPostgresql<Guid, Roulette>, IRouletteRepository
    {
        public RouletteRepository(IConfiguration configuration) : base(configuration) { }
    }
}
