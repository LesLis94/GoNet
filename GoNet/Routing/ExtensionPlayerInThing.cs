using System.Runtime.CompilerServices;
using GoNet.BL.Services.Abstract;
using GoNet.Core.Models;
using GoNet.DataAccess.Abstract;

namespace GoNet.Extensions
{
    public static class ExtensionPlayerInThing
    {
        public static PlayerEntity GetPlayerEntity(this Player player) {

            var playerEntity = new PlayerEntity
            {
                Id = player.Id,
                Name = player.Name,
                Cash = player.Cash
            };

            playerEntity.Things = player.Things
                .Select(thing => thing.GetThingPlayerEntity())
                .ToList();

            return playerEntity; 
        }

        public static ThingPlayerEntity GetThingPlayerEntity(this ThingPlayer thing)
        {
            return new ThingPlayerEntity(thing.Id, thing.Name, thing.IdPlayer);
        }
        public static Player GetPlayer(this PlayerEntity playerEntity)
        {

            var Player = new Player(playerEntity.Id, playerEntity.Name, playerEntity.Cash);

            Player.Things = playerEntity.Things
                .Select(thing => thing.GetThingPlayer())
                .ToList();

            return Player;
        }

        public static ThingPlayer GetThingPlayer(this ThingPlayerEntity thing)
        {
            return new ThingPlayer(thing.Id, thing.Name, thing.IdPlayer);
        }
    }
}
