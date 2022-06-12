using Leopotam.Ecs.Game.Components;
using System;
using UnityEngine;

namespace Leopotam.Ecs.Game.Systems
{
    internal class EndGameCycleSystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<GameEndedComponent> _endEvent = null;
        EcsFilter<ImageObjectComponent> _imageObjects = null;
        EcsFilter<GameConfComponent> _conf = null;
        EcsFilter<GamePlayerComponent, FigureComponent, PlayerGameStatComponent> _playersWithStat = null;
        EcsFilter<GamePlayerComponent, UserComponent, PlayerGameStatComponent> _users = null;

        public void Run()
        {
            if (_endEvent.GetEntitiesCount() == 0)
                return;
            GameEndedComponent res = _endEvent.Get1(0);
            GameConfComponent conf = _conf.Get1(0);
            UpdateStats(res, conf);
            if (_users.GetEntitiesCount() == 0)//если играют не только боты
            {
                _world.SendMessage(new StartGameCycleComponent());
                return;
            }
            UpdateOverlay(res, conf);
        }

        private void UpdateStats(GameEndedComponent res, GameConfComponent conf)
        {
            foreach(var pid in _playersWithStat)
            {
                ref var playerEnt = ref _playersWithStat.GetEntity(pid);
                ref var playerStat = ref playerEnt.Get<PlayerGameStatComponent>();
                if (res.WinnerFigure == PlayerFigure.None)
                    playerStat.Stat.Draws++;
                else if (res.WinnerID == playerEnt.Get<GamePlayerComponent>().PlayerID)
                    playerStat.Stat.Wins++;
                else
                    playerStat.Stat.Loses++;
            }
            if(conf.TacMode == TicTacMode.Bot)
            {
                var pid = _users.Get1(0).PlayerID;
                var statToPlus = new Stat();
                if (res.WinnerFigure == PlayerFigure.None)
                    statToPlus.Draws++;
                else if (res.WinnerID == pid)
                    statToPlus.Wins++;
                else
                    statToPlus.Loses++;
                switch(Bridge.BotDifficulty)
                {
                    case Bot.Easy:
                        PlayerData.EasyBot += statToPlus;
                        break;
                    case Bot.Normal:
                        PlayerData.NormBot += statToPlus;
                        break;
                    case Bot.Hard:
                        PlayerData.HardBot += statToPlus;
                        break;
                }
            }
        }

        private void UpdateOverlay(GameEndedComponent res, GameConfComponent conf)
        {
            foreach (var imgIndex in _imageObjects)
            {
                ref var imageObject = ref _imageObjects.Get1(imgIndex);
                var overlay = imageObject.View.Overlay;
                overlay.SetRayCastBlock();
                if (conf.TacMode == TicTacMode.Bot)
                {
                    var userId = _users.Get1(0).PlayerID;
                    if (res.WinnerFigure == PlayerFigure.None)
                        overlay.SetMid("Draw", new Color(142 / 255f, 142 / 255f, 142 / 255f, 120 / 255f));
                    else if (res.WinnerID == userId)
                        overlay.SetMid("Win", new Color(142 / 255f, 200 / 255f, 142 / 255f, 120 / 255f));
                    else
                        overlay.SetMid("Lose", new Color(200 / 255f, 142 / 255f, 142 / 255f, 120 / 255f));
                }
                else
                {
                    if(res.WinnerFigure == PlayerFigure.None)
                    {
                        overlay.SetPlayer1("Draw", new Color(142 / 255f, 142 / 255f, 142 / 255f, 120 / 255f));
                        overlay.SetPlayer2("Draw", new Color(142 / 255f, 142 / 255f, 142 / 255f, 120 / 255f));
                    }
                    else if(res.WinnerID == 0)
                    {
                        overlay.SetPlayer1("Win", new Color(142 / 255f, 200 / 255f, 142 / 255f, 120 / 255f));
                        overlay.SetPlayer2("Lose", new Color(200 / 255f, 142 / 255f, 142 / 255f, 120 / 255f));
                    }
                    else
                    {
                        overlay.SetPlayer1("Lose", new Color(200 / 255f, 142 / 255f, 142 / 255f, 120 / 255f));
                        overlay.SetPlayer2("Win", new Color(142 / 255f, 200 / 255f, 142 / 255f, 120 / 255f));
                    }
                }
            }
        }
    }
}
