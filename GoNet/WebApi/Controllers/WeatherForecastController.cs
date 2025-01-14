using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Numerics;
using GoNet.BusinessLogic.Services.Abstract;
using GoNet.Core.Models;
using GoNet.WebApi.Contracts;


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
    private readonly IPlayersService _playersService;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IRoulette roulette, IPlayersService playersService, ILogger<WeatherForecastController> logger)
    {
        _roulette = roulette;
        _playersService = playersService;
        _logger = logger;
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
    public async Task<ActionResult<Guid>> PostSaveDBPlayer(PlayerRequest request)
    {
       

        var (player, error) = Player.Create(
            Guid.NewGuid(),
            request.name,
            100);

        /*if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        } */

        var playerId = await _playersService.CreatePlayer(player);

        return Ok(playerId);
        
    }

    [HttpGet("ListPlayers")]
    public async Task<ActionResult<List<PlayerResponse>>> GetPlayers()
    {

        var players = await _playersService.GetAllPlayers();
        var response = players.Select(p => new PlayerResponse(p.Id, p.Name, p.Cash));

        return Ok(response);
    }

    /*
    [HttpGet ("StatusPlayer")]
    public IEnumerable<Players> GetStatusPlayer(Guid guid)
    {

        using (var db = new DataContext())
        {

            Players player = db.Players.Find(guid);
            yield return player;
        }
    }

    */

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

