using Dapper;
using Domain.Common;

namespace Domain.Entities
{
    [Table("user_role")]
    public class UserRol : AbstractEntity<int>
    {
        public  int user_id { get; set; }
        public  int role_id { get; set; }
        public int? organization_id { get; set; }
    }
}
