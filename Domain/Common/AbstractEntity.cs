using Dapper;

namespace Domain.Common 
{ 
    public abstract class AbstractEntity<ID>
    {
        [Key]
        public ID id { get; set; }
    }
}
