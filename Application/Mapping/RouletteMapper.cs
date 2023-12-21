using Application.DTOs.Roulettes;
using Application.Interfaces.Mapping;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Mapping
{
    public class RouletteMapper : MapperBase, IRouletteMapper
    {
        public RouletteModel Convert(Roulette roulette)
        {
            return new RouletteModel()
            {
                Id = roulette.id,
                State = roulette.state
            };
        }

        public List<RouletteModel> Convert(List<Roulette> roulettes)
        {
            return ConvertList(roulettes, (roulete) => Convert(roulete));
        }
    }
}
