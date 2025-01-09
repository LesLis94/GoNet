using System;
using GoNet.BusinessLogic.Services.Abstract;
using GoNet.Core.Models;

namespace GoNet.BL
{
    public class Ruletka : IRoulette
    {
        private Random random = new Random();
        private string[] colors = new string[] { "красное", "черное" };



        public string ResultGame(int valueP, string colorP, Player player)
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

