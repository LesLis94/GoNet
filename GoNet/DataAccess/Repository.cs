using System.Data.Entity;
using GoNet.BL.Services.Abstract;
using GoNet.Core.Abstract;
using GoNet.Core.Models;

namespace GoNet.DataAccess
{
    public class Repository : IRepositoryPlayer
    {

        private readonly DataContext _dbcontext;

        public Repository(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Player>> GetPlayers()
        {
            var playersEntity = await _dbcontext.Players
               // .AsNoTracking() 
                .ToListAsync();

            //.AsNoTracking() // отключает лишнее отслеживание

            var players = playersEntity
                .Select(p => Player.Create(p.Id, p.Name, p.Cash).Player)
                .ToList();

            return players;
        }

        public async Task<Guid> Create(Player player)
        {
            var playerEntity = new PlayerEntity
            {
                Id = player.Id,
                Name = player.Name,
                Cash = player.Cash
            };

            await _dbcontext.Players.AddAsync(playerEntity);
            await _dbcontext.SaveChangesAsync();

            return playerEntity.Id;
        }

    }
}
