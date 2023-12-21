using Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IRepository<ID, Entity>
    {
        Task<ID> CreateAsync(Entity entity);
        Task<Entity> UpdateAsync(Entity entity);
        Task<int> DeleteAsync(Entity id);
        Task<Entity> GetByIdAsync(ID id);
        Task<List<Entity>> GetAllAsync();
        Task<List<Entity>> GetAllWithQuery(string sql, object param);
        Task<List<ID>> InsertAllAsync(List<Entity> entities);
        Task<List<int>> UpdateAllAsync(List<Entity> entities);
        Task<List<Entity>> DeleteAllAsync(List<Entity> entities);
    }
}
