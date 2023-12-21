using Application.DTOs.Roulettes;
using Application.Features.Roulettes.Commands.CreateBetRoulette;
using Application.Interfaces.Mapping;
using Application.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Mapping
{
    public class BetRouletteMapper : MapperBase, IBetRouletteMapper
    {
        public BetRouletteModel Convert(BetRoulette roulette)
        {
            return new BetRouletteModel()
            {
                Bet = roulette.bet,
                Color  = roulette.color,
                Number = roulette.number,
                UserId = roulette.user_id,
                EarnedBet = roulette.earned_bet,
                IsWinner = roulette.winner
            };
        }

        public List<BetRouletteModel> Convert(List<BetRoulette> roulettes)
        {
            return ConvertList(roulettes, (roulete) => Convert(roulete));
        }

        public BetRoulette ConvertEntity(CreateBetRouletteCommand betRouletteCommand)
        {
            return new BetRoulette()
            {
                id = Guid.NewGuid(),
                bet = betRouletteCommand.Bet,
                color = betRouletteCommand.Color,
                number = betRouletteCommand.Number,
                roulette_id = betRouletteCommand.RouletteId,
                user_id = betRouletteCommand.UserId
            };
        }
    }
}
