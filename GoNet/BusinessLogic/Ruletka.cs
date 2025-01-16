using System;
using GoNet.BusinessLogic.Services.Abstract;
using GoNet.Core.Models;

namespace GoNet.BL
{
    public class Ruletka : IRoulette
    {
        private Random random = new Random();
        private string[] colors = new string[] { "красное", "черное" };



        public string ResultGame(int valueP, string colorP, Player player, int bid)
        {

            int value = ResultValue();
            string color = ResultColor();

            if (String.Equals(color, colorP, StringComparison.OrdinalIgnoreCase))
            {
                if (value == valueP)
                {
                    int money = bid * 2;
                    player.PutMoney(money);
                    return $"{value} {color} {money}";
                }
            }

            //return Convert.ToString(value + " " + color);
            player.GiveMoney(bid);
            return $"{value} {color} -{bid}";
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

