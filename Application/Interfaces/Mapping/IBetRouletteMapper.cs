using Application.DTOs.Roulettes;
using Application.Features.Roulettes.Commands.BetRoulette;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces.Mapping
{
    public interface IBetRouletteMapper
    {
        BetRoulette ConvertEntity(BetRouletteCommand betRouletteCommand);
        BetRouletteModel Convert(BetRoulette betRoulette);
        List<BetRouletteModel> Convert(List<BetRoulette> betRoulettes);
    }
}
