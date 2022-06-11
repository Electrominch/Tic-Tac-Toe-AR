using Leopotam.Ecs;
using Leopotam.Ecs.Game.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Leopotam.Ecs.Game.Systems
{
    public class GameInitSystem : IEcsInitSystem
    {
        EcsWorld _world = null;

        public void Init()
        {
            SetPlayers(Bridge.PlayMode == TicTacMode.Bot ? 1:2);
            _world.NewEntity().Get<FieldComponent>();
            _world.NewEntity().Get<GameInfoComponent>().CellCount = 9;
            _world.SendMessage(new StartGameCycleComponent());
        }

        private void SetPlayers(int users)
        {
            int players = 2;
            while (players-- > 0)
            {
                var ent = _world.NewEntity();
                ent.Get<GamePlayerComponent>() = new GamePlayerComponent(players);
                if (users-- > 0)
                    ent.Get<UserComponent>();
                else
                    ent.Get<BotComponent>().BotDif = Bridge.BotDifficulty;
            }
        }
    }
}