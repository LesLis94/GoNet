//using System.Data.Entity;
using GoNet.BL.Services.Abstract;
using GoNet.Core.Abstract;
using GoNet.Core.Models;
using GoNet.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GoNet.DataAccess
{
    public class RepositoryPlayer : IRepositoryPlayer
    {

        private readonly DataContext _dbcontext;

        public RepositoryPlayer(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Player>> GetPlayers()
        {
            var playersEntity = await _dbcontext.Players
                .AsNoTracking() 
                .ToListAsync();

            //.AsNoTracking() // отключает лишнее отслеживание

            var players = playersEntity
                .Select(p => Player.Create(p.Id, p.Name, p.Cash).Player)
                .ToList();

            return players;
        }

        public async Task<Player> GetPlayerInfo(Guid id)
        {
            var playersEntity = await _dbcontext.Players
                .AsNoTracking()
                .Include(p => p.Things)
                .FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception($"Player not found");

            //.FirstOrDefaultAsync() // вернет первый найденный по условию
            var player = Player.Create(playersEntity.Id, playersEntity.Name, playersEntity.Cash).Player;

            foreach (ThingPlayerEntity thing in playersEntity.Things)
            {
                player.Things.Add(new ThingPlayer ( thing.Id, thing.Name, thing.IdPlayer, player ));
            }

            return player;
        }

        public async Task<Guid> Create(Player player)
        {
            var playerEntity = new PlayerEntity
            {
                Id = player.Id,
                Name = player.Name,
                Cash = player.Cash
            };

            foreach (ThingPlayer thing in player.Things)
            {
                playerEntity.Things.Add(new ThingPlayerEntity { Id = thing.Id, Name = thing.Name, IdPlayer = thing.IdPlayer, Player = playerEntity});
            }

            await _dbcontext.Players.AddAsync(playerEntity);
            foreach (ThingPlayerEntity thing in playerEntity.Things)
            {
                await _dbcontext.Things.AddAsync(thing);
            }
            await _dbcontext.SaveChangesAsync();

            return playerEntity.Id;
        }

        public async Task Update(Guid id, int cash)
        {
            await _dbcontext.Players.Where(p => p.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Cash, cash));
        }

        public async Task Delete(Guid id)
        {
            await _dbcontext.Players.Where(p => p.Id == id).ExecuteDeleteAsync();
        }

    }
}
