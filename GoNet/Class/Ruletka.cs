using System;
using GoNet.Interfaces;

namespace GoNet.Class
{
	public class Ruletka : IRoulette
	{
        public Random random = new Random();
		public string[] colors = new string[] { "красное", "черное" };
		


        public string ResultGame(int valueP, string colorP, Players player)
		{

			int value = ResultValue();
			string color = ResultColor();



            //return Convert.ToString(value + " " + color);
            return $"{value} {color}";
		}

		public int ResultValue()
		{
			return random.Next(1, 26);
        }

        public string ResultColor()
        {
            return colors[random.Next(0, 2)];
        }

       
    }
}

