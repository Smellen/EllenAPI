using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SteamGameStatistics.API.Controllers
{
    [Route("api/gameStats")]
    [ApiController]
    public class GameStatistics : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetGameStats()
        {
            return Ok("Ok");
        }
    }
}
