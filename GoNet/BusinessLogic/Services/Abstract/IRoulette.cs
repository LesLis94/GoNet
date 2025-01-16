using System;
using GoNet.Core.Models;

namespace GoNet.BusinessLogic.Services.Abstract
{
    public interface IRoulette
    {
        /// <summary>
        /// Отдаем в класс рулетка
        /// </summary>
        /// <param name="valueP"></param>
        /// <param name="colorP"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        string ResultGame(int valueP, string colorP, Player player, int bid);
    }
}

