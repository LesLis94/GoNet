using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Numerics;
using GoNet.BL.Services.Abstract;
using GoNet.BL.Services.Abstract.Interfaces;


namespace GoNet.DAL.Controllers;

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

    // private static List<Players> players = new List<Players>();

    // private int NextPlayersId => players.Count() == 0 ? 1 : players.Max(x => x.Id) + 1;



    private readonly IRoulette _roulette;
    

    public WeatherForecastController(IRoulette roulette)
    {
        _roulette = roulette;
    }

    /*
    [HttpPost("WritePlayer")]
    public IActionResult PostSavePlayer(Players player)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

       // player.Id = NextPlayersId;
       player.Id = Guid.NewGuid();
        players.Add(player);
        return Ok();
    } */

    [HttpPost ("SaveDBPlayer")]
    public IActionResult PostSaveDBPlayer(Players player)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        player.Id = Guid.NewGuid();
        using (var db = new DBContext1())
        {
            db.Players.Add(player);
            db.SaveChanges();

            return Ok();
        }
    }

    [HttpGet("ListPlayers")]
    public IEnumerable<Players> GetPlayers()
    {

        using (var db = new DBContext1())
        {

            var player = db.Players.ToList();

            return player;
        }
    }

    [HttpGet ("StatusPlayer")]
    public IEnumerable<Players> GetStatusPlayer(Guid guid)
    {

        using (var db = new DBContext1())
        {

            Players player = db.Players.Find(guid);
            yield return player;
        }
    }

    [HttpDelete ("Exit")]
    public IActionResult ExitPlayer()
    {

        return Ok();
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

