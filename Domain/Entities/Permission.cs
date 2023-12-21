using Dapper;
using Domain.Common;

namespace Domain.Entities
{
    [Table("permission")]
    public class Permission : AbstractEntity<int>
    {
        public string name { get; set; }

        public string description { get; set; }
    }
}
