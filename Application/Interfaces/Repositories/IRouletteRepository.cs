using Domain.Entities;
using System;

namespace Application.Interfaces.Repositories
{
    public interface IRouletteRepository : IRepository<Guid, Roulette>
    {
    }
}
