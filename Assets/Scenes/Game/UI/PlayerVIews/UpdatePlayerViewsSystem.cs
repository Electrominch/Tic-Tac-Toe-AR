using Leopotam.Ecs.Game.Components;
using Leopotam.Ecs.Game.UI.Components;
using System.Collections.Generic;
using UnityEngine;

namespace Leopotam.Ecs.Game.UI.Systems
{
    internal class UpdatePlayerViewsSystem : IEcsRunSystem
    {
        private EcsFilter<UpdatePlayerViewsComponent> _event = null;
        EcsFilter<GamePlayerComponent, FigureComponent, PlayerGameStatComponent> _allUsers = null;
        EcsFilter<PlayerViewComponent> _playerViews = null;

        public void Run()
        {
            if (_event.GetEntitiesCount() == 0)
                return;
            var updateBots = _event.Get1(0).UpdateBots;
            Dictionary<int, PlayerView> id_views = new Dictionary<int, PlayerView>();
            foreach (var view in _playerViews)
            {
                var curPlayerViewComp = _playerViews.Get1(view);
                id_views.Add(curPlayerViewComp.ID, curPlayerViewComp.View);
            }

            foreach (var i in _allUsers)
            {
                ref var playerEnt = ref _allUsers.GetEntity(i);
                int pid = _allUsers.Get1(i).PlayerID;
                if (!id_views.ContainsKey(pid))
                    continue;
                if (id_views[pid].IsUserView)
                    id_views[pid].UpdateUserStats(_allUsers.Get3(i).Stat);
                else if(updateBots)
                {
                    string text = "";
                    var botEnt = _allUsers.GetEntity(i);
                    if (botEnt.Get<BotComponent>().BotDif == Bot.Tournament)
                        text = $"Tournament\nPlayer No.{botEnt.Get<PlayerGameStatComponent>().Stat.Loses + 1}";
                    else
                        text = botEnt.Get<BotComponent>().BotDif.ToString();
                    id_views[pid].UpdateBot(text);
                }
                id_views[pid].SetFigure((int)_allUsers.Get2(i).Figure-1);
            }
        }
    }
}
