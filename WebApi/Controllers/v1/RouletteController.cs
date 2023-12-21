using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.Roulette;
using Application.Features.Roulettes.Commands.BetRoulette;
using Application.Features.Roulettes.Commands.CreateRoulette;
using Application.Features.Roulettes.Queries.GetAllRoulette;
using Application.Interfaces.Services;
using Application.Wrappers;
using Infrastructure.Identity.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RouletteController : BaseApiController
    {
        private readonly IUserContextResolverService<int> UserContextResolverService;

        public RouletteController(IUserContextResolverService<int> userContextResolverService)
        {
            UserContextResolverService = userContextResolverService;
        }   

        [HttpGet]
        [SwaggerOperation(Summary = "Get all roulettes")]
        [ResourceAuthorize("roulette", "read")]
        public async Task<ActionResult<Response<List<RouletteModel>>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllRouletteQuery()));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create Roulette")]
        [ResourceAuthorize("roulette", "new")]
        public async Task<ActionResult<Response<RouletteModel>>> Create([FromBody] CreateRouletteCommand createRouletteCommand)
        {
            return Ok(await Mediator.Send(createRouletteCommand));
        }

        [HttpPut("{rouletteId}")]
        [SwaggerOperation(Summary = "Open Roulette")]
        [ResourceAuthorize("roulette", "open")]
        public async Task<ActionResult<Response<RouletteModel>>> OpenRoulette([FromRoute] Guid rouletteId)
        {
            return Ok(await Mediator.Send(new OpenRouletteCommand()
            {
                Id = rouletteId
            }));
        }

        [HttpPost("{rouletteId}/Bet")]
        [SwaggerOperation(Summary = "New Bet Roulette")]
        [Authorize]
        [ResourceAuthorize("roulette", "bet")]
        public async Task<ActionResult<Response<RouletteModel>>> BetRoulette([FromRoute] Guid rouletteId, [FromBody] BetRouletteCommand betRouletteCommand)
        {
            betRouletteCommand.UserId = UserContextResolverService.GetUserId();
            betRouletteCommand.RouletteId = rouletteId;

            return Ok(await Mediator.Send(betRouletteCommand));
        }
    }
}