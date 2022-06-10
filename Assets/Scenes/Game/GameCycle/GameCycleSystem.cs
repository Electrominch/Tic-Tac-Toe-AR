using Assets.Scenes.Game.GameCycle.Cell;
using Assets.Scenes.Game.GameCycle.StartGame;
using Leopotam.Ecs;
using Leopotam.Ecs.Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.Game.GameCycle
{
    internal class GameCycleSystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<GameMoveComponent> _moves = null;
        EcsFilter<GamePlayerComponent> _allPlayers = null;
        EcsFilter<GamePlayerComponent, FigureComponent, PlayerTurn> _curPlayer = null;
        EcsFilter<FieldComponent> _field = null;

        public void Run()
        {
            if (_moves.GetEntitiesCount() == 0 || _curPlayer.GetEntitiesCount() == 0)
                return;
            if (_curPlayer.GetEntitiesCount() > 1)
                throw new Exception("More 2 players");
            ref var curPlayer = ref _curPlayer.GetEntity(0);
            ref var field = ref _field.Get1(0);
            foreach (var i in _moves)
            {
                var move = _moves.Get1(i);
                Debug.Log($"Move {curPlayer.Get<GamePlayerComponent>().PlayerID} in {move.X}:{move.Y} with {curPlayer.Get<FigureComponent>().Figure}");
                field.Field[move.Y][move.X] = (int)curPlayer.Get<FigureComponent>().Figure;
                _moves.GetEntity(i).Del<GameMoveComponent>();
            }
            NextPlayerTurn();
            _world.SendMessage(new UpdateCellsComponent());
        }

        private void NextPlayerTurn()//передача хода другому игроку
        {
            var curPlayer = _curPlayer.GetEntity(0);
            curPlayer.Del<PlayerTurn>();
            int next = curPlayer.Get<GamePlayerComponent>().PlayerID + 1;
            if (next >= _allPlayers.GetEntitiesCount())
                next = 0;
            foreach (var p in _allPlayers)
                if (_allPlayers.Get1(p).PlayerID == next)
                {
                    _allPlayers.GetEntity(p).Get<PlayerTurn>();
                    break;
                }
        }
    }
}
