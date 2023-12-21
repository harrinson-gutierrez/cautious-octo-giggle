using Domain.Common;
using System;

namespace Domain.Entities
{
    public class BetRoulette : AbstractEntity<Guid>
    {
        public Guid roulette_id { get; set; }
        public int user_id { get; set; }
        public decimal bet { get; set; }
        public int? number { get; set; } 
        public string color { get; set; }
    }
}
