using Bots;
using Leopotam.Ecs.Game.Components;
using System.Collections.Generic;
using UnityEngine;

namespace Leopotam.Ecs.Game.Systems
{
    internal class BotGameMoveSystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<GamePlayerComponent, BotComponent, FigureComponent, PlayerTurnComponent> _bot = null;
        EcsFilter<FieldComponent> _field;
        EcsFilter<ImageObjectComponent> _imageObjects = null;//чтобы блокировать клеточки на время хода бота

        private static Dictionary<Bot, IBot> _bots = new Dictionary<Bot, IBot>()
        {
            { Bot.Easy, new EasyBot() },
            { Bot.Normal, new NormalBot() },
            { Bot.Hard, new HardBot() },
            { Bot.Tournament, new EasyBot() },
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
                        _world.SendMessage(new GameMoveComponent(botCell.X, botCell.Y));
                        curBot.Moving = false;
                        foreach (var imgObj in _imageObjects)
                            _imageObjects.Get1(imgObj).SetInteractable(true);
                    }
                    else
                        continue;
                }
                else
                {
                    curBot.Moving = true;
                    curBot.TimeForEndMove = Time.time + Random.Range(300, 600) / 1000f;
                    foreach (var imgObj in _imageObjects)
                        _imageObjects.Get1(imgObj).SetInteractable(false);
                }
            }
        }
    }
}
