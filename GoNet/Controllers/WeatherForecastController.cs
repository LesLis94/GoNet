using Microsoft.AspNetCore.Mvc;
using GoNet.Class;

namespace GoNet.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }


    [HttpGet("resultGame")]
    public string GetInt()
    {
        //Ruletka.resultGame();
        return Ruletka.resultGame();
    }

    [HttpPost("EnterValueColor")]
    public string EnterValueColor(string stavka, int id)
    {



        return "Ваша ставка записана";
    }

}

