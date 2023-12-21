using Dapper;
using Domain.Common;

namespace Domain.Entities
{
    [Table("role_permission")]
    public class RolePermission : AbstractEntity<int>
    {
        public int role_id { get; set; }
        public int permission_id { get; set; }
    }
}
