using System;
using System.ComponentModel.DataAnnotations;

namespace GoNet.BL.Services.Abstract
{
    public class PlayerEntity
    {

        public int Cash { get; set; } = 100;

        public Guid Id { get; set; }

        public string Name { get; set; }

       

    }
}

