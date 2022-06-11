using Assets.Scenes.Game.GameCycle.PlayerInfo.User;
using Leopotam.Ecs;
using Leopotam.Ecs.Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.Game.GameCycle.User
{
    internal class UserGameMoveSystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<UserGameMoveComponent> _moves = null;
        EcsFilter<GamePlayerComponent, UserComponent, PlayerTurnComponent> _userPlayers = null;

        public void Run()
        {
            foreach(var moveIndex in _moves)
            {
                var move = _moves.Get1(moveIndex);
                foreach(var pIndex in _userPlayers)
                {
                    _world.SendMessage(new GameMoveComponent(move.X, move.Y));
                }
                _moves.GetEntity(moveIndex).Del<UserGameMoveComponent>();
            }
        }
    }
}
