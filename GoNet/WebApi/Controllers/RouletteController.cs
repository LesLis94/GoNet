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
        public string EnterValueColor(int value, string color, int idPlayer)
        {

            /* Players player = players.SingleOrDefault(p => p.Id == idPlayer);

             //Ruletka ruletka = new Ruletka();

             //  string result = ResultGame(ruletka, value, color, player);
             string result = _roulette.ResultGame(value, color, player);

             return "Ваша ставка записана. " + result;
            */
            return "Ваша ставка записана. ";
        }

    }
}
