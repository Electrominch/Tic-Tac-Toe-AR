using Leopotam.Ecs.Game.Components;
using System;
using System.Collections.Generic;

namespace Bots
{
    internal class EasyBot : IBot
    {
        private static Random _rnd = new Random();
        public (int, int) Move(PlayerFigure[][] field, PlayerFigure me)
        {
            List<(int, int)> emptyCells = new List<(int, int)>();
            for (int y = 0; y < field.Length; y++)
                for (int x = 0; x < field[y].Length; x++)
                    if (field[y][x] == PlayerFigure.None)
                        emptyCells.Add((x, y));
            var rndCell = emptyCells[_rnd.Next(0, emptyCells.Count)];
            return (rndCell.Item1, rndCell.Item2);
        }
    }
}
