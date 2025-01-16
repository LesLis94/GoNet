using System.Numerics;
using GoNet.BL.Services.Abstract;
using GoNet.Core.Abstract;
using GoNet.Core.Models;
using GoNet.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GoNet.DataAccess
{
    public class RepositoryThingPlayer : IRepositoryThingPlayer
    {
        private readonly DataContext _dbcontext;

        public RepositoryThingPlayer(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task Delete(Guid id)
        {
            await _dbcontext.Things.Where(p => p.Id == id).ExecuteDeleteAsync();
        }

        public async Task<Guid> Create(ThingPlayer thing)
        {
            var playerEntity = new PlayerEntity
            {
                Id = thing.Player.Id,
                Name = thing.Player.Name,
                Cash = thing.Player.Cash
            };

            var thingPlayerEntity = new ThingPlayerEntity
            {
                Id = thing.Id,
                Name = thing.Name,
                IdPlayer = thing.IdPlayer,
                Player = playerEntity
            };

            playerEntity.Things.Add(thingPlayerEntity);

            await _dbcontext.Things.AddAsync(thingPlayerEntity);
            await _dbcontext.SaveChangesAsync();

            return thingPlayerEntity.Id;
        }
    }
}
