using Application.DTOs.Roulettes;
using System;
using System.Collections.Generic;

namespace Application.DTOs.Roulette
{
    public class RouletteModel
    {
        public Guid Id { get; set; }
        public string State { get; set; }

        public List<BetRouletteModel> Bets { get; set; }
    }
}
