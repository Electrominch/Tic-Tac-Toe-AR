using Leopotam.Ecs.Game.Components;

namespace Leopotam.Ecs.Game.Systems
{
    internal class UpdateCellsContentSystem : IEcsRunSystem
    {
        EcsFilter<UpdateCellsContentComponent> _updateEvents = null;
        EcsFilter<ImageObjectComponent> _imageObjects = null;
        EcsFilter<FieldComponent> _field = null;


        public void Run()
        {
            if (_updateEvents.GetEntitiesCount() == 0)
                return;
            PlayerFigure[][] field = _field.Get1(0).Field;
            foreach(var imageObjectIndex in _imageObjects)
            {
                ref var imageObjectComponent = ref _imageObjects.Get1(imageObjectIndex);
                for(int y = 0; y < field.Length; y++)
                    for(int x = 0; x < field[y].Length; x++)
                    {
                        imageObjectComponent.Cells[y][x].SetContent((int)field[y][x]-1);
                    }
            }
        }
    }
}
