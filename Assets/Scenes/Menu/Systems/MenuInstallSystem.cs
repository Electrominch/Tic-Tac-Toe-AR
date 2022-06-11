using Leopotam.Ecs.Game.Components;
using Leopotam.Ecs.Menu.Components;
using Leopotam.Ecs.Menu.UI.Components;

namespace Leopotam.Ecs.Menu.Systems
{
    public class MenuInstallSystem : IEcsInitSystem
    {
        EcsWorld _world = null;

        public void Init()
        {
            SetGameConf();
            _world.SendMessage(new BeginUINavigateComponent("MainMenu"));
            _world.SendMessage(new UpdateMarkersEventComponent());
        }

        private void SetGameConf()
        {
            ref var conf = ref _world.NewEntity().Get<GameConfComponent>();
            _world.SendMessage(new ChangeBotComponent() { Target = Bot.Easy });
        }
    }

}