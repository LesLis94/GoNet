using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GoNet.BusinessLogic.Services.Abstract;
using GoNet.Core.Models;
using GoNet.WebApi.Contracts;
using GoNet.BusinessLogic;
using System.Security.Policy;

namespace GoNet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IRoulette _roulette;
        private readonly IPlayersService _playersService;
        private readonly IBank _bank;

        public PlayerController(IRoulette roulette, IPlayersService playersService, IBank bank)
        {
            _roulette = roulette;
            _playersService = playersService;
            _bank = bank;
        }

        [HttpPost("SaveDBPlayer")]
        public async Task<ActionResult<Guid>> PostSaveDBPlayer(PlayerRequest request)
        {

            var (player, error) = Player.CreateNew(
                Guid.NewGuid(),
                request.name,
                100);

            var playerId = await _playersService.CreatePlayer(player);

            return Ok(playerId);

        }

        [HttpPatch("UpdatePlayer")]
        public async Task<ActionResult> UpdatePlayer(Guid id, int cash)
        {
            await _playersService.Update(id, cash);
            return Ok(id);
        }

        [HttpGet("ListPlayers")]
        public async Task<ActionResult<List<PlayerResponse>>> GetPlayers()
        {

            var players = await _playersService.GetAllPlayers();
            var response = players.Select(p => new PlayerResponse(p.Id, p.Name, p.Cash));

            return Ok(response);
        }

        [HttpGet("GetInfoPlayer")]
        public async Task<PlayerInfo> GetInfoPlayer(Guid id)
        {
            var player = await _playersService.GetPlayerInfo(id);
            var response = new PlayerInfo(player.Name, player.Cash, player.Things);

            return response;
        }

        [HttpDelete("Exit")]
        public async Task<ActionResult> DeletePlayer(Guid id)
        {
            await _playersService.Delete(id);
            return Ok();
        }

        [HttpPost("SaleThing")]
        public async Task<ActionResult> SaleThing(Guid id, Guid idThing)
        {
            var player = await _playersService.GetPlayerInfo(id);
            _playersService.PutMoney((int)_bank.SaleThingPlayer(idThing), player);
            //player.Cash += (int)_bank.SaleThingPlayer(idThing);
            await _playersService.Update(id, player.Cash);

            return Ok(player.Cash);
        }
    }
}
