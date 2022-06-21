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
            if (TicTacUtils.CheckEndOfGame(field, 3, out var res, out CellXY[] winCells))
                _world.SendMessage(new GameEndedComponent(curPlayer.Get<GamePlayerComponent>().PlayerID, res, winCells));
            else
                NextPlayerTurn();
            _world.SendMessage(new UpdateCellsContentComponent());
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
    }
}
