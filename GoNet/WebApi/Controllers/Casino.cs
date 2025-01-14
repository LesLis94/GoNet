﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GoNet.BusinessLogic.Services.Abstract;
using GoNet.Core.Models;
using GoNet.WebApi.Contracts;

namespace GoNet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Casino : ControllerBase
    {
        private readonly IRoulette _roulette;
        private readonly IPlayersService _playersService;

        public Casino (IRoulette roulette, IPlayersService playersService)
        {
            _roulette = roulette;
            _playersService = playersService;
        }

        [HttpPost("SaveDBPlayer")]
        public async Task<ActionResult<Guid>> PostSaveDBPlayer(PlayerRequest request)
        {

            var (player, error) = Player.Create(
                Guid.NewGuid(),
                request.name,
                100);

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

        [HttpGet("GetInfoPlayer")]
        public async Task<PlayerInfo> GetInfoPlayer(Guid id)
        {
            var player = await _playersService.GetPlayerInfo(id);
            var response = new PlayerInfo(player.Name, player.Cash);

            return response;
        }

        [HttpDelete("Exit")]
        public async Task<ActionResult> DeletePlayer(Guid id)
        {
            await _playersService.Delete(id);
            return Ok();
        }
    }
}
