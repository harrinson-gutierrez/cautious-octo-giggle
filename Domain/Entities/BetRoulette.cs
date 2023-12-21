using Dapper;
using Domain.Common;
using System;

namespace Domain.Entities
{
    [Table("bet_roulette")]
    public class BetRoulette : AbstractEntity<Guid>
    {
        public Guid roulette_id { get; set; }
        public int user_id { get; set; }
        public decimal bet { get; set; }
        public int? number { get; set; } 
        public string color { get; set; }
        public bool winner { get; set; }
        public decimal earned_bet { get; set; }
    }
}
