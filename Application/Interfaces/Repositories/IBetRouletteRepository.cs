using Domain.Entities;
using System;

namespace Application.Interfaces.Repositories
{
    public interface IBetRouletteRepository : IRepository<Guid, BetRoulette>
    {
    }
}
