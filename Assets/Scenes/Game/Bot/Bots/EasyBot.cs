using Leopotam.Ecs.Game.Components;
using System.Collections.Generic;
using UnityEngine;

namespace Bots
{
    internal class EasyBot : IBot
    {
        public CellXY Move(PlayerFigure[][] field, PlayerFigure me)
        {
            var empty = TicTacUtils.EmptyCells(field);
            var rndCell = empty[Random.Range(0, empty.Count)];
            return rndCell;
        }
    }
}
