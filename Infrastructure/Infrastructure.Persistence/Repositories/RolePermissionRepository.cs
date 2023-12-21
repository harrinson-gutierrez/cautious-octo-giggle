using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Repositories
{
    public class RolePermissionRepository: RepositoryPostgresql<int, RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(IConfiguration configuration) : base(configuration) { }
    }
}
