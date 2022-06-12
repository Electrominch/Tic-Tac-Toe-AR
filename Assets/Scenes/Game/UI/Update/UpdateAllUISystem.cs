using Leopotam.Ecs.Game.Components;
using Leopotam.Ecs.Game.UI.Components;

namespace Leopotam.Ecs.Game.UI.Systems
{
    internal class UpdateAllUISystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<UpdateAllUIComponent> _event = null;

        public void Run()
        {
            if (_event.GetEntitiesCount() == 0)
                return;

            _world.SendMessage(new UpdateCellsContentComponent());
            _world.SendMessage(new UpdatePlayerViewsComponent());

            foreach (var i in _event)
                _event.GetEntity(i).Del<UpdateAllUIComponent>();
        }
    }
}
