﻿using Leopotam.Ecs;
using Leopotam.Ecs.Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.Game.GameCycle.StartGame
{
    internal class StartGameCycleSystem : IEcsRunSystem
    {
        EcsFilter<StartGameCycleComponent> _start = null;
        EcsFilter<GamePlayerComponent> _players = null;
        EcsFilter<FieldComponent> _field = null;
        EcsFilter<GameInfoComponent> _gi = null;

        public void Run()
        {
            if (_start.GetEntitiesCount() == 0)
                return;
            Debug.Log("Starting Cycle..");
            SetUpField();
            RandomTurn();
            RandomFigures();
            foreach (var i in _start)
                _start.GetEntity(i).Del<StartGameCycleComponent>();
        }

        private void RandomFigures()//случайное распределение фигурок
        {
            var rnd = UnityEngine.Random.Range(0, 2);
            _players.GetEntity(0).Replace(new FigureComponent(rnd==0?PlayerFigure.Crosses:PlayerFigure.Noughts));
            _players.GetEntity(1).Replace(new FigureComponent(rnd==1?PlayerFigure.Crosses:PlayerFigure.Noughts));
        }

        private void RandomTurn()//случайный игрок получает возможность ходить первым
        {
            int rndP = UnityEngine.Random.Range(0, _players.GetEntitiesCount());
            _players.GetEntity(rndP).Get<PlayerTurn>();
        }

        private void SetUpField()
        {
            ref var field = ref _field.Get1(0);
            var side = (int)MathF.Sqrt(_gi.Get1(0).CellCount);
            field.Field = new int[side][];
            for (int i = 0; i < field.Field.Length; i++)
                field.Field[i] = Enumerable.Repeat(0, side).ToArray();
        }
    }
}