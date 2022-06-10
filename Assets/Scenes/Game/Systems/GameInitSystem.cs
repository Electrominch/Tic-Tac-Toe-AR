using Assets.Scenes.Game.GameCycle;
using Assets.Scenes.Game.GameCycle.StartGame;
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
            SetPlayers();
            _world.NewEntity().Get<FieldComponent>();
            _world.NewEntity().Get<GameInfoComponent>().CellCount = 9;
            _world.SendMessage(new StartGameCycleComponent());
        }

        private void SetPlayers()
        {
            int players = 2;
            while (players-- > 0)
                _world.NewEntity().Get<GamePlayerComponent>() = new GamePlayerComponent(players);
        }
    }
}