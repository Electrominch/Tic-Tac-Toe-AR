using Leopotam.Ecs.Common.SceneNavigate;
using Leopotam.Ecs.Game.Components;
using System;

namespace Leopotam.Ecs.Game.UI.Systems
{
    internal class GameUIInitSystem : IEcsInitSystem
    {
        EcsWorld _world = null;
        GameUIView _ui = null;
        EcsFilter<GamePlayerComponent, UserComponent, PlayerGameStatComponent> _users = null;

        public void Init()
        {
            _ui.BackToMenuButton.onClick.AddListener(() =>
            {
                if(Bridge.BotDifficulty == Bot.Tournament && Bridge.PlayMode == TicTacMode.Bot)
                    PlayerData.TryAddResult(new TournamentRes(_users.Get3(0).Stat.Wins, DateTime.Now));
                _world.SendMessage(new NavigateToSceneComponent("Menu"));
            });
        }
    }
}
