using GoNet.BL.Services.Abstract;
using GoNet.Core.Models;

namespace GoNet.DataAccess.Abstract
{
    public class ThingPlayerEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid IdPlayer { get; set; }
        //public PlayerEntity? Player { get; set; }

        public ThingPlayerEntity(Guid id, string name, Guid idPlayer)
        {
            Id = id;
            Name = name;
            IdPlayer = idPlayer;
        }
    }
}
