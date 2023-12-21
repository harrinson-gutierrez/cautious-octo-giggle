using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<int, AppUser>
    {
        Task<List<AppUser>> GetUsers();
        Task<List<AppUserLogin>> GetAppUserLoginsByUser(int userId);
        Task<AppUserLogin> GetAppUserLoginByUserAndProvider(string loginProvider, string providerKey);
        Task<AppUserLogin> CreateAppUserLogin(AppUserLogin appUserLogin);
        Task<AppUser> GetUserById(int userId);
        Task<AppUser> GetUserByEmail(string email);

    }
}
