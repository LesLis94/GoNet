using GoNet.Core.Models;

namespace GoNet.Core.Abstract
{
    public interface IRepositoryPlayer
    {
        Task<Guid> Create(Player player);
        Task<List<Player>> GetPlayers();
    }
}