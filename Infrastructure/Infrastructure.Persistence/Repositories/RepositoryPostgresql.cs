using Application.Interfaces.Repositories;
using Dapper;
using Domain.Common;
using Infrastructure.Persistence.Extensions;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class RepositoryPostgresql<ID, Entity> : BaseRepository, IRepository<ID, Entity>
    {
        public RepositoryPostgresql(IConfiguration configuration) : base(configuration) {  }

        public virtual async Task<ID> CreateAsync(Entity entity)
        {
            var conn = new NpgsqlConnection(ConnectionString);
            return await conn.InsertAsync<ID, Entity>(entity);
        }

        public virtual async Task<int> DeleteAsync(Entity entity)
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);
            return await conn.DeleteAsync(entity);
        }

        public virtual async Task<List<Entity>> GetAllAsync()
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);
            return (await conn.GetListAsync<Entity>()).AsList();
        }

        public virtual async Task<Entity> GetByIdAsync(ID id)
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);
            return await conn.GetAsync<Entity>(id);
        }

        public virtual async Task<Entity> UpdateAsync(Entity entity)
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);
            await conn.UpdateAsync(entity);
            return entity;
        }
        public virtual async Task<List<Entity>> GetAllWithQuery(string sql, object param)
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);
            return (await conn.GetListAsync<Entity>(sql, param)).AsList();
        }
        public virtual async Task<List<ID>> InsertAllAsync(List<Entity> entities)
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);
            return await conn.InsertAllAsync<ID, Entity>(entities);
        }

        public virtual async Task<List<int>> UpdateAllAsync(List<Entity> entities)
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);
            return await conn.UpdateAllAsync<ID, Entity>(entities);
        }
        public virtual async Task<List<Entity>> DeleteAllAsync(List<Entity> entities)
        {
            using IDbConnection conn = new NpgsqlConnection(ConnectionString);
            return await conn.DeleteAllAsync<ID, Entity>(entities);
        }
    }
}
