using GoNet.BusinessLogic.Services.Abstract;

namespace GoNet.BusinessLogic
{
    public class Bank : IBank
    {
        static Random random = new Random();
        public IThingsPlayersService _thingsPlayersService;

        public Bank(IThingsPlayersService thingsPlayersService) =>  _thingsPlayersService = thingsPlayersService;

        public decimal SaleThingPlayer(Guid idThing)
        {
            decimal money = (decimal)random.NextDouble() * 100;

            _thingsPlayersService.Delete(idThing);

            return money;
        }
    }
}
