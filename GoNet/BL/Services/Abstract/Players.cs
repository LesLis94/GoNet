using System;
using System.ComponentModel.DataAnnotations;

namespace GoNet.BL.Services.Abstract
{
    public class Players
    {

        public int Cash { get; set; }

        public Guid Id { get; set; }

        // делает поле обязательным
        [Required]
        public string Name { get; set; }

        public Players()
        {
            Cash = 100;
        }

    }
}

