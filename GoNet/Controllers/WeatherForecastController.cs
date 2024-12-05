using Microsoft.AspNetCore.Mvc;
using GoNet.Class;

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






    [HttpGet("resultGame")]
    public string GetInt()
    {
        //Ruletka.resultGame();
        Ruletka ruletka = new Ruletka();

        return ruletka.resultGame();
    }

    [HttpPost("EnterValueColor")]
    public string EnterValueColor(int value, string color, int idPlayer)
    {

        var player = players.SingleOrDefault(p => p.Id == idPlayer);



        return "Ваша ставка записана";
    }

}

