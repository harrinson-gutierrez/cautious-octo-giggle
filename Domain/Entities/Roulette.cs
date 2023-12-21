using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Roulette : AbstractEntity<Guid>
    {
        public string Id { get; set; }
        public string State { get; set; }
    }
}
