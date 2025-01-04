using System;
using System.ComponentModel.DataAnnotations;

namespace GoNet.BL.Services.Abstract
{
    public class Players
    {

        public int Cash = 100;

        public Guid Id { get; set; }

        // делает поле обязательным
        [Required]
        public string Name { get; set; }

    }
}

