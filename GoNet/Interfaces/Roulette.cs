﻿using System;
using GoNet.Class;

namespace GoNet.Interfaces
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
        string ResultGame(int value, string color, Players player);

    }
}

