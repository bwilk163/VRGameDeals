using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VRGameDeals.Data.Models;
using VRGameDeals.Data.Services;

namespace VRGameDeals.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {

        private readonly PlatformsService _platformsService;

        public PlatformsController(PlatformsService platformsService)
        {
            _platformsService = platformsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allPlatforms = await _platformsService.GetAll();
            return Ok(allPlatforms);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Platform game)
        {
            var result = await _platformsService.Add(game);

            return Created("", result);
        }
        [HttpPut("{guid}")]
        public async Task<IActionResult> Add([FromBody] Platform game, Guid guid)
        {
            var result = await _platformsService.Update(guid, game);
            return Created("", result);
        }
    }
}