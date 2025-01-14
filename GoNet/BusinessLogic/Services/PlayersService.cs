using GoNet.BusinessLogic.Services.Abstract;
using GoNet.Core.Abstract;
using GoNet.Core.Models;

namespace GoNet.BusinessLogic.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly IRepositoryPlayer _repositoryPlayer;

        public PlayersService(IRepositoryPlayer repositoryPlayer) { _repositoryPlayer = repositoryPlayer; }

        public async Task<List<Player>> GetAllPlayers()
        {
            return await _repositoryPlayer.GetPlayers();
        }

        public async Task<Guid> CreatePlayer(Player player)
        {
            return await _repositoryPlayer.Create(player);
        }

        public async Task<Player> GetPlayerInfo(Guid id)
        {
            return await _repositoryPlayer.GetPlayerInfo(id);
        }

        public async Task Update(Guid id, int cash)
        {
            await _repositoryPlayer.Update(id, cash);
        }

        public async Task Delete(Guid id)
        {
            await _repositoryPlayer.Delete(id);
        }
    }
}
