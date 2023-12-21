using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Repositories
{
    public class RoleRepository : RepositoryPostgresql<int, AppRol>, IRoleRepository
    {
        public RoleRepository(IConfiguration configuration) : base(configuration) { }
    }
}
