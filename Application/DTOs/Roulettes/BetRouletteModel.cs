﻿namespace Application.DTOs.Roulettes
{
    public class BetRouletteModel
    {
        public decimal Bet { get; set; }
        public int? Number { get; set; } 
        public string Color { get; set; }
        public int UserId { get; set; }
        public decimal EarnedBet { get; set; }
        public bool IsWinner { get; set; }
    }
}
