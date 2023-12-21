using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;

namespace Infrastructure.Persistence.Repositories
{
    public class BetRouletteRepository : RepositoryPostgresql<Guid, BetRoulette>, IBetRouletteRepository
    {
        public BetRouletteRepository(IConfiguration configuration) : base(configuration) { }
    }
}
