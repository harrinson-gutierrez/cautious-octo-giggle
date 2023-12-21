﻿using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Stores
{
    public class UserStoreRepository : BaseRepository, IUserRoleStore<AppUser>, 
                                                       IUserPasswordStore<AppUser>, 
                                                       IUserEmailStore<AppUser>, 
                                                       IUserSecurityStampStore<AppUser>
    {

        public UserStoreRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
        {
            using IDbConnection con = new NpgsqlConnection(ConnectionString);
            await con.InsertAsync<int, AppUser>(user);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
        {
            using (IDbConnection con = new NpgsqlConnection(ConnectionString))
            {
                await con.DeleteAsync(user);
                return IdentityResult.Success;
            }
        }

        public async Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            using (IDbConnection con = new NpgsqlConnection(ConnectionString))
            {
                return await con.QuerySingleOrDefaultAsync<AppUser>(@"SELECT * FROM app_user
                                                           WHERE id = @userId", new { userId = Guid.Parse(userId) });
            }
        }

        public async Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            using IDbConnection con = new NpgsqlConnection(ConnectionString);
            return await con.QueryFirstOrDefaultAsync<AppUser>(@"SELECT * FROM app_user
                                                           WHERE username = @normalizedUserName", new { normalizedUserName });
        }

        public Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.username);
        }

        public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.id.ToString());
        }

        public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.username);
        }

        public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.username = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken)
        {
            user.username = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
        {
            using (IDbConnection con = new NpgsqlConnection(ConnectionString))
            {
                await con.UpdateAsync(user);
                return IdentityResult.Success;
            }
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.password_hash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.password_hash);
        }

        public async Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
        {
            return !string.IsNullOrEmpty(await GetPasswordHashAsync(user, cancellationToken));
        }

        public Task SetEmailAsync(AppUser user, string email, CancellationToken cancellationToken)
        {
            user.email = email;
            return Task.CompletedTask;
        }

        public Task<string> GetEmailAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.email);
        }

        public Task<bool> GetEmailConfirmedAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.email_confirmed);
        }

        public Task SetEmailConfirmedAsync(AppUser user, bool confirmed, CancellationToken cancellationToken)
        {
            user.email_confirmed = confirmed;
            return Task.CompletedTask;
        }

        public async Task<AppUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            using (IDbConnection con = new NpgsqlConnection(ConnectionString))
            {
                return await con.QueryFirstOrDefaultAsync<AppUser>(@"SELECT * FROM app_user
                                                           WHERE UPPER(email) = @normalizedEmail", new { normalizedEmail });
            }
        }

        public Task<string> GetNormalizedEmailAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.email);
        }
   
        public Task SetNormalizedEmailAsync(AppUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.email = normalizedEmail;
            return Task.CompletedTask;
        }

        public async Task AddToRoleAsync(AppUser user, string roleName, CancellationToken cancellationToken)
        {
            using (IDbConnection con = new NpgsqlConnection(ConnectionString))
            {
                await con.QueryAsync(@"INSERT INTO user_role(user_id,role_id) 
                                        SELECT @userId, role.id 
                                        FROM role 
                                        WHERE role.name = @roleName", new { userId = user.id, roleName });
            }
        }

        public async Task RemoveFromRoleAsync(AppUser user, string roleName, CancellationToken cancellationToken)
        {
            using (IDbConnection con = new NpgsqlConnection(ConnectionString))
            {
                await con.ExecuteAsync(@"DELETE FROM user_role usr
                                        INNER JOIN role ON role.role_id = usr.role_id
                                        WHERE usr.user_id = @userId AND role.name = @roleName",
                                        new { userId = user.id, roleName });
            }
        }

        public async Task<IList<string>> GetRolesAsync(AppUser user, CancellationToken cancellationToken)
        {
            using (IDbConnection con = new NpgsqlConnection(ConnectionString))
            {
                return (await con.QueryAsync<string>(@"SELECT r.name
                                      FROM user_role AS ur 
                                      JOIN role AS r ON ur.role_id = r.id
                                      WHERE ur.user_id = @userId",
                                      new { userId = user.id })).AsList();
            }
        }

        public async Task<bool> IsInRoleAsync(AppUser user, string roleName, CancellationToken cancellationToken)
        {
            var roles = await GetRolesAsync(user, cancellationToken);
            return roles.Contains(roleName);
        }

        public async Task<IList<AppUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            using (IDbConnection con = new NpgsqlConnection(ConnectionString))
            {
                return (IList<AppUser>)(await con.QueryAsync(
                  @"SELECT u.* 
                      FROM user_role AS ur
                      JOIN role AS r ON ur.role_id = r.id
                      JOIN app_user AS u ON ur.user_id = u.id
                      WHERE r.name = @roleName",
                  new { roleName })
                ).AsList();
            }
        }

        public void Dispose()
        {
        }

        public Task SetSecurityStampAsync(AppUser user, string stamp, CancellationToken cancellationToken)
        {
            user.security_stamp = stamp;
            return Task.CompletedTask;
        }

        public Task<string> GetSecurityStampAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.security_stamp);
        }

        public Task ReplaceCodesAsync(AppUser user, IEnumerable<string> recoveryCodes, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RedeemCodeAsync(AppUser user, string code, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountCodesAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
