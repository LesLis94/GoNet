using System;
using System.ComponentModel.DataAnnotations;

namespace GoNet.Class
{
	public class Players
	{

        public int Cash = 100;

        public int Id { get; set; }

        // делает поле обязательным
        [Required] 
		public string Name { get; set; }

    }
}

