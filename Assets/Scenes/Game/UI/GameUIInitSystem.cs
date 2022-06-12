using Leopotam.Ecs.Common.SceneNavigate;

namespace Leopotam.Ecs.Game.UI.Systems
{
    internal class GameUIInitSystem : IEcsInitSystem
    {
        EcsWorld _world = null;
        GameUIView _ui = null;

        public void Init()
        {
            _ui.BackToMenuButton.onClick.AddListener(() => _world.SendMessage(new NavigateToSceneComponent("Menu")));
        }
    }
}
