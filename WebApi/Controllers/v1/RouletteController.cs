using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.Roulette;
using Application.Features.Roulettes.Commands.CreateRoulette;
using Application.Features.Roulettes.Queries.GetAllRoulette;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RouletteController : BaseApiController
    {
        [HttpGet]
        [SwaggerOperation(Summary = "Get all roulettes")]
        public async Task<ActionResult<Response<List<RouletteModel>>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllRouletteQuery()));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create Roulette")]
        public async Task<ActionResult<Response<RouletteModel>>> Create([FromBody] CreateRouletteCommand createRouletteCommand)
        {
            return Ok(await Mediator.Send(createRouletteCommand));
        }

        [HttpPost("{rouletteId}")]
        [SwaggerOperation(Summary = "Open Roulette")]
        public async Task<ActionResult<Response<RouletteModel>>> OpenRoulette([FromRoute] Guid rouletteId)
        {
            return Ok(await Mediator.Send(new OpenRouletteCommand()
            {
                Id = rouletteId
            }));
        }
    }
}