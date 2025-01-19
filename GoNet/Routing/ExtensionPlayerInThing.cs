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

            return playerEntity; 
        }

        public static void GetThingPlayerEntity(this PlayerEntity playerEntity, Player player)
        {

            playerEntity.Things = player.Things
                .Select(thing => new ThingPlayerEntity { Id = thing.Id, Name = thing.Name, IdPlayer = thing.IdPlayer, Player = playerEntity })
                .ToList();
        }

    }
}
