using Application.DTOs.Roulettes;
using Application.Features.Roulettes.Commands.CreateBetRoulette;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces.Mapping
{
    public interface IBetRouletteMapper
    {
        BetRoulette ConvertEntity(CreateBetRouletteCommand betRouletteCommand);
        BetRouletteModel Convert(BetRoulette betRoulette);
        List<BetRouletteModel> Convert(List<BetRoulette> betRoulettes);
    }
}
