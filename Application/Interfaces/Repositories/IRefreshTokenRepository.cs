using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IRefreshTokenRepository : IRepository<Guid, RefreshToken>
    {
        Task<RefreshToken> GetByJwtId(Guid jwtId);
    }
}
