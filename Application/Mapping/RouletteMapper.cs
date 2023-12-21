using Application.DTOs.Roulette;
using Application.Interfaces.Mapping;
using Application.Mappings;
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
                State = roulette.State
            };
        }

        public List<RouletteModel> Convert(List<Roulette> roulettes)
        {
            return ConvertList(roulettes, (roulete) => Convert(roulete));
        }
    }
}
