using GoNet.BusinessLogic.Services.Abstract;
using GoNet.Core.Abstract;
using GoNet.Core.Models;
using GoNet.DataAccess;

namespace GoNet.BusinessLogic.Services
{
    public class ThingsPlayersService : IThingsPlayersService
    {
        private readonly IRepositoryThingPlayer _repositoryThingPlayer;
        public ThingsPlayersService(IRepositoryThingPlayer repositoryThingPlayer) { _repositoryThingPlayer = repositoryThingPlayer; }

        public async Task Delete(Guid id)
        {
            await _repositoryThingPlayer.Delete(id);
        }

        /* public async Task<Guid> Create(ThingPlayer thing)
        {
            return await _repositoryThingPlayer.Create(thing);
        } */
    }
}
