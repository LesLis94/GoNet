using Microsoft.AspNetCore.Mvc;
using GoNet.Class;
using GoNet.Interfaces;
using System.Drawing;
using System.Numerics;

namespace GoNet.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    /* private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    } */

    private static List<Players> players = new List<Players>();

    private int NextPlayersId => players.Count() == 0 ? 1 : players.Max(x => x.Id) + 1;

    private readonly IRoulette _roulette;

    public WeatherForecastController(IRoulette roulette)
    {
        _roulette = roulette;
    }

    [HttpGet("ListPlayers")]
    public IEnumerable<Players> GetPlayers() => players;

    [HttpPost("WritePlayer")]
    public IActionResult PostSavePlayer(Players player)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        player.Id = NextPlayersId;
        players.Add(player);
        return Ok();
    }




   //private string ResultGame(IRoulette roulette, int value, string color, Players player) => roulette.ResultGame(value, color, player);

   /* [HttpGet("resultGame")]
    public string GetInt()
    {
        //Ruletka.resultGame();
        Ruletka ruletka = new Ruletka();

        return ruletka.ResultGame();
    } */

    [HttpPost("EnterValueColor")]
    public string EnterValueColor(int value, string color, int idPlayer)
    {

       Players player = players.SingleOrDefault(p => p.Id == idPlayer);

        //Ruletka ruletka = new Ruletka();

      //  string result = ResultGame(ruletka, value, color, player);
        string result = _roulette.ResultGame(value, color, player);

        return "Ваша ставка записана. " + result;
    }

}

