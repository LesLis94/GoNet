using GoNet.Core.Models;

namespace GoNet.BusinessLogic.Services.Abstract
{
    public interface IPlayersService
    {
        Task<Guid> CreatePlayer(Player player);
        Task<List<Player>> GetAllPlayers();
    }
}