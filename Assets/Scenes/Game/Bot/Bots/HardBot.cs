using Leopotam.Ecs.Game.Components;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bots
{
    internal class HardBot : IBot
    {
        public CellXY Move(PlayerFigure[][] field, PlayerFigure me)
        {
            if (NextMove(field, me, out CellXY next))
                return next;
            var empty = TicTacUtils.EmptyCells(field);
            var rndCell = empty[Random.Range(0, empty.Count)];
            return rndCell;
        }

        private bool NextMove(PlayerFigure[][] field, PlayerFigure me, out CellXY nextMove)
        {
            var empty = TicTacUtils.EmptyCells(field);
            foreach (var cell in empty)
            {
                field[cell.Y][cell.X] = me;
                if (TicTacUtils.CheckEndOfGame(field, 3, out _, out _))
                {
                    field[cell.Y][cell.X] = PlayerFigure.None;
                    nextMove = cell;
                    return true;
                }
                field[cell.Y][cell.X] = PlayerFigure.None;
            }
            foreach (var cell in empty)
            {
                field[cell.Y][cell.X] = me == PlayerFigure.Crosses ? PlayerFigure.Noughts : PlayerFigure.Crosses;
                if (TicTacUtils.CheckEndOfGame(field, 3, out _, out _))
                {
                    field[cell.Y][cell.X] = PlayerFigure.None;
                    nextMove = cell;
                    return true;
                }
                field[cell.Y][cell.X] = PlayerFigure.None;
            }
            nextMove = new CellXY();
            return false;
        }
    }
}
