using System;
using System.ComponentModel.DataAnnotations;
using GoNet.DataAccess.Abstract;

namespace GoNet.BL.Services.Abstract
{
    public class PlayerEntity
    {

        public int Cash { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<ThingPlayerEntity> Things { get; set; } = [];

    }
}

