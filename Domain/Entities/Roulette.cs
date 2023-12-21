using Dapper;
using Domain.Common;
using System;

namespace Domain.Entities
{
    [Table("roulette")]
    public class Roulette : AbstractEntity<Guid>
    {
        public string state { get; set; }
    }
}
