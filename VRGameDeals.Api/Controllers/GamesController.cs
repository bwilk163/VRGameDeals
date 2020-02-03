using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VRGameDeals.Api.Commands;
using VRGameDeals.Data.Models;
using VRGameDeals.Data.Services;

namespace VRGameDeals.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesService _gamesService;

        public GamesController(GamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allGames = await _gamesService.GetAll();

            return Ok(allGames);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Game game)
        {
            var result = await _gamesService.Add(game);

            return Created("", result);
        }
        [HttpPut("{guid}")]
        public async Task<IActionResult> Update([FromBody] Game game, Guid guid)
        {
            var result = await _gamesService.Update(guid, game);

            return Created("", result);
        }

        [HttpPost("{gameId}")]
        public async Task<IActionResult> AddPlatformToGame(Guid gameId, [FromBody] PlatformGameCommand platformGameCommand)
        {
            var result = await _gamesService.AddPlatformToGame(
                gameId,
                platformGameCommand.PlatformId,
                platformGameCommand.ReleaseDate,
                platformGameCommand.Price
                );

            return Ok(result);
        }
    }
}