using System;
namespace GoNet.Class
{
	public class Ruletka
	{
        public Random random = new Random();
		public string[] colors = new string[] { "красное", "черное" };
		


        public string resultGame()
		{

			var value = resultValue();
			var color = resultColor();

            //return Convert.ToString(value + " " + color);
            return $"{value} {color}";
		}

		public int resultValue()
		{
			return random.Next(1, 26);
        }

        public string resultColor()
        {
            return colors[random.Next(0, 2)];
        }



    }
}

