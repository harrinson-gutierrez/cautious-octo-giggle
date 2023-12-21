using System;

namespace Domain.Common
{
    public abstract class AuditableBaseEntity<ID> : AbstractEntity<ID>
    {
        public int created_by { get; set; }
        public DateTime created { get; set; }
        public int update_by { get; set; }
        public DateTime? updated { get; set; }
    }
}
