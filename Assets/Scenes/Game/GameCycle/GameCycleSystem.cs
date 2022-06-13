using Leopotam.Ecs.Game.Components;
using Leopotam.Ecs.Game.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Leopotam.Ecs.Game.Systems
{
    internal class GameCycleSystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<GameMoveComponent> _moves = null;
        EcsFilter<GamePlayerComponent> _allPlayers = null;
        EcsFilter<GamePlayerComponent, FigureComponent, PlayerTurnComponent> _curPlayer = null;
        EcsFilter<FieldComponent> _field = null;

        public void Run()
        {
            if (_moves.GetEntitiesCount() == 0 || _curPlayer.GetEntitiesCount() == 0)
                return;
            if (_curPlayer.GetEntitiesCount() > 1)
                throw new Exception("More 2 players");
            ref var curPlayer = ref _curPlayer.GetEntity(0);
            curPlayer.Del<PlayerTurnComponent>();//отнимаем ход у текущего игрока
            var field = _field.Get1(0).Field;
            foreach (var i in _moves)
            {
                var move = _moves.Get1(i);
                field[move.Y][move.X] = curPlayer.Get<FigureComponent>().Figure;
                _moves.GetEntity(i).Del<GameMoveComponent>();
            }
            if (CheckEndOfGame(field, 3, out var res, out CellXY[] winCells))
                _world.SendMessage(new GameEndedComponent(curPlayer.Get<GamePlayerComponent>().PlayerID, res, winCells));
            else
                NextPlayerTurn();
            _world.SendMessage(new UpdateAllUIComponent());
        }

        private bool CheckEndOfGame(PlayerFigure[][] field, int lineForWin, out PlayerFigure winFigure, out CellXY[] winCells)
        {
            CellStat[][] checkTable = new CellStat[field.Length][];
            CellStat idle = new CellStat(1,1,1,1);
            for (int i = 0; i < checkTable.Length; i++)
                checkTable[i] = Enumerable.Repeat(idle, field[i].Length).ToArray();
            bool fullField = true;
            for(int y = 0; y < field.Length; y++)
                for(int x = 0; x < field[y].Length; x++)
                {
                    var cur = field[y][x];
                    if(cur == PlayerFigure.None)
                    {
                        fullField = false;
                        continue;
                    }

                    int lx = x - 1;
                    int uy = y - 1;
                    if (lx >= 0)//проверка слева
                    {
                        if (field[y][lx] == cur)//проврка на этой же высоте
                            checkTable[y][x].EqualsLeft = checkTable[y][lx].EqualsLeft + 1;
                        if (uy>=0 && field[uy][lx]==cur)//проврка выше
                            checkTable[y][x].EqualsTopLeft = checkTable[uy][lx].EqualsTopLeft + 1;
                    }
                    int rx = x + 1;
                    if(uy>=0) // проверка сверху
                    {
                        var up = field[uy];
                        if (up[x] == cur)
                            checkTable[y][x].EqualsTop = checkTable[uy][x].EqualsTop + 1;
                        if (rx < up.Length && up[rx] == cur)
                            checkTable[y][x].EqualsTopRight = checkTable[uy][rx].EqualsTopRight + 1;
                    }

                    if (checkTable[y][x].Win(lineForWin, new CellXY(x,y), out winCells))
                    {
                        winFigure = field[y][x];
                        return true;
                    }
                }
            winFigure = PlayerFigure.None;
            winCells = new CellXY[0];
            return fullField;
        }

        private void NextPlayerTurn()//передача хода другому игроку
        {
            var curPlayer = _curPlayer.GetEntity(0);
            int next = curPlayer.Get<GamePlayerComponent>().PlayerID + 1;
            if (next >= _allPlayers.GetEntitiesCount())
                next = 0;
            foreach (var p in _allPlayers)
                if (_allPlayers.Get1(p).PlayerID == next)
                {
                    _allPlayers.GetEntity(p).Get<PlayerTurnComponent>();
                    break;
                }
        }

        private struct CellStat
        {
            public int EqualsLeft;
            public int EqualsTopLeft;
            public int EqualsTop;
            public int EqualsTopRight;

            public CellStat(int l, int tl, int t, int tr)
            {
                EqualsLeft = l;
                EqualsTopLeft = tl;
                EqualsTop = t;
                EqualsTopRight = tr;
            }

            public bool Win(int length, CellXY curCell, out CellXY[] winCells)
            {
                List<CellXY> cells = new List<CellXY>();
                bool win = false;
                if (EqualsLeft >= length)
                {
                    while(length-- > 0)
                    {
                        cells.Add(curCell);
                        curCell.X--;
                    }
                    win = true;
                }
                else if(EqualsTopLeft >= length)
                {
                    while (length-- > 0)
                    {
                        cells.Add(curCell);
                        curCell.X--;
                        curCell.Y--;
                    }
                    win = true;
                }
                else if(EqualsTop >= length)
                {
                    while (length-- > 0)
                    {
                        cells.Add(curCell);
                        curCell.Y--;
                    }
                    win = true;
                }
                else if(EqualsTopRight >= length)
                {
                    while (length-- > 0)
                    {
                        cells.Add(curCell);
                        curCell.X++;
                        curCell.Y--;
                    }
                    win = true;
                }

                if(win)
                {
                    winCells = cells.ToArray();
                    return true;
                }

                winCells = new CellXY[0];
                return false;
            }

            public override string ToString()
            {
                return $"[{EqualsLeft}, {EqualsTopLeft}, {EqualsTop}, {EqualsTopRight}]";
            }
        }
    }
}
