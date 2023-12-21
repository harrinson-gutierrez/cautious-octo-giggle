using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IUserRoleRepository : IRepository<int, UserRol>
    {
        Task<List<AppRol>> GetRolesByUserId(int userId);
    }
}
