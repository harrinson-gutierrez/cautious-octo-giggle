
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IPermissionRepository :  IRepository<int, Permission>
    {
        Task<List<Permission>> GetPermissionsByUserId(int userId);
        Task<List<Permission>> GetPermissionsByRolId(int roleId);
    }
}
