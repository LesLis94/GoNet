using GoNet.Core.Models;
using GoNet.WebApi.Contracts;

namespace GoNet.BusinessLogic.Services.Abstract
{
    public interface IPlayersService
    {
        Task<Player> GetPlayerInfo(Guid id);
        Task<Guid> CreatePlayer(Player player);
        Task Delete(Guid id);
        Task<List<Player>> GetAllPlayers();
        Task Update(Guid id, int cash);
        void GiveMoney(int bid, Player player);
        void PutMoney(int money, Player player);
        Task<PlayerInfo> GetPlayerInfoApi(Guid id);
        Task<List<PlayerResponse>> GetAllPlayersResponse();
    }
}