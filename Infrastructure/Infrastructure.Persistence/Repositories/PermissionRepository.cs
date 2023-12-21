using Application.Interfaces.Repositories;
using Dapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class PermissionRepository : RepositoryPostgresql<int, Permission>, IPermissionRepository
    {
        public PermissionRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<List<Permission>> GetPermissionsByUserId(int userId)
        {
            var conn = new NpgsqlConnection(ConnectionString);

            return (await conn.QueryAsync<Permission>(@"SELECT permission.* FROM permission
                                                        INNER JOIN role_permission ON role_permission.permission_id = permission.id
                                                        INNER JOIN ""role"" ON role_permission.role_id =  ""role"".id
                                                        INNER JOIN user_role ON user_role.role_id = ""role"".id
                                                        WHERE user_role.user_id = @userId", new { userId })).AsList();
        }

        public async Task<List<Permission>> GetPermissionsByRolId(int roleId)
        {
            var conn = new NpgsqlConnection(ConnectionString);

            return (await conn.QueryAsync<Permission>(@"SELECT permission.* FROM permission
                                                        INNER JOIN role_permission ON role_permission.permission_id = permission.id
                                                        INNER JOIN ""role"" ON role_permission.role_id =  ""role"".id
                                                        WHERE ""role"".id = @roleId", new { roleId })).AsList();
        }
    }
}
