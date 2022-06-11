using Assets.Scenes.Game.GameCycle.Bot.Bots;
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
        private static System.Random _rnd = new System.Random();
        private static Dictionary<Leopotam.Ecs.Game.Components.Bot, IBot> _bots = new Dictionary<Leopotam.Ecs.Game.Components.Bot, IBot>()
        {
            { Leopotam.Ecs.Game.Components.Bot.Easy, new EasyBot() },
        };

        public void Run()
        {
            foreach(var i in _bot)
            {
                ref BotComponent curBot = ref _bot.Get2(i);
                ref FigureComponent curFigure = ref _bot.Get3(i);
                if (curBot.Moving)
                {
                    if (Time.time > curBot.TimeForEndMove)
                    {
                        var field = _field.Get1(0).Field;
                        var botCell = _bots[curBot.BotDif].Move(field, curFigure.Figure);
                        _world.SendMessage(new GameMoveComponent(botCell.Item1, botCell.Item2));
                        curBot.Moving = false;
                    }
                    else
                        continue;
                }
                else
                {
                    curBot.Moving = true;
                    curBot.TimeForEndMove = Time.time + _rnd.Next(300, 600) / 1000f;
                }
            }
        }
    }
}
