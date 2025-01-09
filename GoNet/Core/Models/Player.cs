using System;
using System.ComponentModel.DataAnnotations;

namespace GoNet.Core.Models
{
    public class Player
    {

        public int Cash { get; set; }

        public Guid Id { get; set; }

        // делает поле обязательным
        [Required]
        public string Name { get; set; }

        private Player(Guid id, string name, int cash)
        {
            Id = id;
            Name = name;
            Cash = cash;
        }

        public static (Player Player, string Error) Create(Guid id, string name, int cash)
        {
            var error = string.Empty;

            var player = new Player(id, name, cash);

            return (player, error);
        }


    }
}

