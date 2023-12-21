using Application.DTOs.Roulette;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces.Mapping
{
    public interface IRouletteMapper
    {
        RouletteModel Convert(Roulette roulette);
        List<RouletteModel> Convert(List<Roulette> roulettes);
    }
}
