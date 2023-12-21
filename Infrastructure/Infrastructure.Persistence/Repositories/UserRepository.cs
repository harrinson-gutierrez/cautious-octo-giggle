using Dapper;
using Domain.Entities;
using Application.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository : RepositoryPostgresql<int, AppUser>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<List<AppUserLogin>> GetAppUserLoginsByUser(int userId)
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);

            return (await conn.QueryAsync<AppUserLogin>("SELECT * FROM user_login WHERE user_id = @userId", new { userId})).AsList();
        }

        public async Task<AppUserLogin> GetAppUserLoginByUserAndProvider(string loginProvider, string providerKey)
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);

            return await conn.QuerySingleOrDefaultAsync<AppUserLogin>(@"SELECT * FROM user_login
                                                    WHERE login_provider = @loginProvider
                                                    AND provider_key = @providerKey", new { loginProvider, providerKey });
        }

        public async Task<List<AppUser>> GetUsers()
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);
            return (await conn.QueryAsync<AppUser>("SELECT * FROM app_user")).AsList();
        }

        public async Task<AppUserLogin> CreateAppUserLogin(AppUserLogin appUserLogin)
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);

            await conn.InsertAsync<string, AppUserLogin>(appUserLogin);

            return appUserLogin;
        }

        public async Task<AppUser> GetUserById(int userId)
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);
            return await conn.QueryFirstOrDefaultAsync<AppUser>("SELECT * FROM app_user WHERE id = @userId", new { userId});
        }

        public async Task<AppUser> GetUserByEmail(string email)
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);
            return await conn.QueryFirstOrDefaultAsync<AppUser>("SELECT * FROM app_user WHERE email = @email", new { email });
        }
    }
}
