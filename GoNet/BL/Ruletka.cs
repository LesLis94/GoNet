using System;
using GoNet.BL.Services.Abstract;
using GoNet.BL.Services.Abstract.Interfaces;

namespace GoNet.BL
{
    public class Ruletka : IRoulette
    {
        private Random random = new Random();
        private string[] colors = new string[] { "красное", "черное" };



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

