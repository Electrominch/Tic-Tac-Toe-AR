using Leopotam.Ecs.Menu.UI.Components;

namespace Leopotam.Ecs.Menu.UI.Systems
{
    internal class UpdateMarkersSystem : IEcsRunSystem
    {
        EcsFilter<MarkerDisplayComponent> _md = null;
        EcsFilter<UpdateMarkersEventComponent> _update = null;

        public void Run()
        {
            if (_update.GetEntitiesCount() > 0)
            {
                foreach (var i in _md)
                    _md.Get1(i).MarkersDisplay.Display();
                foreach (var i in _update)
                    _update.GetEntity(i).Del<UpdateMarkersEventComponent>();
            }
        }
    }
}
