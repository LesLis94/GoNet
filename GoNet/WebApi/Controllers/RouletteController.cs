using System.Security.Policy;
using GoNet.BusinessLogic.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoNet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRoulette _roulette;
        private readonly IPlayersService _playersService;

        public RouletteController(IRoulette roulette, IPlayersService playersService)
        {
            _roulette = roulette;
            _playersService = playersService;
        }

        [HttpPost("EnterValueColor")]
        public async Task<ActionResult<string>> EnterValueColor(int value, string color, Guid idPlayer, int bid)
        {

            var player = await _playersService.GetPlayerInfo(idPlayer);
            if (player.Cash < bid) return BadRequest($"Cash is small");

            string result = _roulette.ResultGame(value, color, player, bid);
            await _playersService.Update(idPlayer, player.Cash);

            return "Ваша ставка записана. " + result;
            
            //return "Ваша ставка записана. ";
        }

    }
}
