using Leopotam.Ecs.Menu.UI.Components;

namespace Leopotam.Ecs.Menu.UI.Systems
{
    internal class BeginUINavigateSystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<BeginUINavigateComponent> _change = null;
        MainSceneUIView _ui = null;

        public void Run()
        {
            if (_change.GetEntitiesCount() == 0 || _ui.BlackoutService.Started)
            {
                foreach (var i in _change)
                    _change.GetEntity(i).Destroy();
                return;
            }

            var needUIPart = _change.Get1(0);
            _ui.BlackoutService.StartBlackoutCycle(() => {
                _world.SendMessage(new EndUINavigateComponent() { PartName = needUIPart.PartName });
                _ui.Background.Restart();
            }, needUIPart.Delay);
        }
    }
}
