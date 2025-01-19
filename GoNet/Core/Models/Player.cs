using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using GoNet.BusinessLogic.Services;
using GoNet.BusinessLogic.Services.Abstract;
using GoNet.DataAccess.Abstract;

namespace GoNet.Core.Models
{
    public class Player
    {
        public int Cash { get; set; }
        public Guid Id { get; set; }    
        // делает поле обязательным
        [Required]
        public string Name { get; set; }
        public List<ThingPlayer> Things { get; set; }

        public Player(Guid id, string name, int cash)
        {
            Id = id;
            Name = name;
            Cash = cash;
            Things = new List<ThingPlayer>();
        }

        public static (Player Player, string Error) CreateNew(Guid id, string name, int cash)
        {
            var error = string.Empty;
            var player = new Player(id, name, cash);

            for (int i = 0; i < 3; i++)
            {
                player.Things.Add(ThingPlayer.CreateRandom(id, player));
            }

            return (player, error);
        }

        
    }
}

