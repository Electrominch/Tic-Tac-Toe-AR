using Assets.Scenes.Game.GameCycle.StartGame;
using Leopotam.Ecs;
using Leopotam.Ecs.Game.Components;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.Game.GameCycle.Bot
{
    internal class BotGameMoveSystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<GamePlayerComponent, BotComponent, FigureComponent, PlayerTurnComponent> _bot = null;
        EcsFilter<FieldComponent> _field;

        public void Run()
        {
            foreach(var i in _bot)
            {
                var field = _field.Get1(0).Field;
                List<(int, int)> emptyCells = new List<(int, int)>();
                for(int y = 0; y < field.Length; y++)
                    for(int x = 0; x < field[y].Length; x++)
                        if (field[y][x] == PlayerFigure.None)
                            emptyCells.Add((x, y));
                var rnd = emptyCells[Random.Range(0, emptyCells.Count)];
                _world.SendMessage(new GameMoveComponent(rnd.Item1, rnd.Item2));
            }
        }
    }
}
