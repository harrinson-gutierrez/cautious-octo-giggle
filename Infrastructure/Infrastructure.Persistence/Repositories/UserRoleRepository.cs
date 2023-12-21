using Application.Interfaces.Repositories;
using Dapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRoleRepository : RepositoryPostgresql<int, UserRol>,  IUserRoleRepository
    {
        public UserRoleRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<List<AppRol>> GetRolesByUserId(int userId)
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);
            return (await conn.QueryAsync<AppRol>(@"SELECT r.* FROM user_role
                                                    INNER JOIN role r ON user_role.role_id = r.id
                                                    WHERE user_role.user_id = @userId", new { userId })).AsList();
        }
    }
}
