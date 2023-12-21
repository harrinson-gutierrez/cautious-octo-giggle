using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Stores
{
    public class RoleStoreRepository : BaseRepository, IRoleStore<AppRol>
    {
        public RoleStoreRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<IdentityResult> CreateAsync(AppRol role, CancellationToken cancellationToken)
        {
            using IDbConnection con = new NpgsqlConnection(ConnectionString);
            await con.InsertAsync<Guid, AppRol>(role);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(AppRol role, CancellationToken cancellationToken)
        {
            using IDbConnection con = new NpgsqlConnection(ConnectionString);
            await con.DeleteAsync(role);
            return IdentityResult.Success;
        }

        public async Task<AppRol> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            using IDbConnection con = new NpgsqlConnection(ConnectionString);
            return await con.QuerySingleOrDefaultAsync<AppRol>(@"SELECT * FROM role
                                                           WHERE id = @roleId", new { roleId });
        }

        public async Task<AppRol> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            using IDbConnection con = new NpgsqlConnection(ConnectionString);
            return await con.QuerySingleOrDefaultAsync<AppRol>(@"SELECT * FROM role
                                                           WHERE name = @normalizedUserName", new { normalizedRoleName });
        }

        public Task<string> GetNormalizedRoleNameAsync(AppRol role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.name);
        }

        public Task<string> GetRoleIdAsync(AppRol role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.id.ToString());
        }

        public Task<string> GetRoleNameAsync(AppRol role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.name);
        }

        public Task SetNormalizedRoleNameAsync(AppRol role, string normalizedName, CancellationToken cancellationToken)
        {
            role.name = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetRoleNameAsync(AppRol role, string roleName, CancellationToken cancellationToken)
        {
            role.name = roleName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(AppRol role, CancellationToken cancellationToken)
        {
            using IDbConnection con = new NpgsqlConnection(ConnectionString);
            await con.UpdateAsync(role);
            return IdentityResult.Success;
        }

        public void Dispose()
        {
            
        }
    }
}
