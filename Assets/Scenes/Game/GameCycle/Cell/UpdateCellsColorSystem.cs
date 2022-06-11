using Leopotam.Ecs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.Game.GameCycle.Cell
{
    internal class UpdateCellsColorSystem : IEcsRunSystem
    {
        EcsFilter<UpdateCellsColorComponent> _updateEvents = null;
        EcsFilter<ImageObjectComponent> _imageObjects = null;


        public void Run()
        {
            if (_updateEvents.GetEntitiesCount() == 0)
                return;
            var colors = new Color[3] { Extencions.GetRandomColor(), Extencions.GetRandomColor(), Extencions.GetRandomColor() };
            foreach (var imageObjectIndex in _imageObjects)
            {
                ref var imageObjectComponent = ref _imageObjects.Get1(imageObjectIndex);
                for (int y = 0; y < imageObjectComponent.Cells.Length; y++)
                    for (int x = 0; x < imageObjectComponent.Cells[y].Length; x++)
                    {
                        imageObjectComponent.Cells[y][x].SetColors(colors[0], colors[1], colors[2]);
                    }
            }
        }
    }
}
