using GoNet.Core.Models;

namespace GoNet.Core.Abstract
{
    public interface IRepositoryPlayer
    {
        Task<Guid> Create(Player player);
        Task Delete(Guid id);
        Task<Player> GetPlayerInfo(Guid id);
        Task<List<Player>> GetPlayers();
        Task Update(Guid id, int cash);
    }
}