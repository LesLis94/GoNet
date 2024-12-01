using System;
namespace GoNet.Class
{
	public static class Ruletka
	{
        private static Random random = new Random();
		private static string[] colors = new string[] { "красное", "черное" };
		


        public static string resultGame()
		{

			int value = random.Next(1, 26);
			string color = colors[random.Next(0, 2)];

			return Convert.ToString(value + " " + color);

		}



	}
}

