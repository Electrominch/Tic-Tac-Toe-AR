using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.Game.GameCycle.Cell
{
    internal class UpdateCellsSystem : IEcsRunSystem
    {
        EcsFilter<CellComponent> _cells = null;
        EcsFilter<UpdateCellsComponent> _updates = null;
        EcsFilter<FieldComponent> _field = null;


        public void Run()
        {
            if (_updates.GetEntitiesCount() == 0)
                return;
            foreach (var cellIndex in _cells)
            {
                var curCell = _cells.Get1(cellIndex).Cell;
                curCell.SetContent(_field.Get1(0).Field[curCell.Y][curCell.X]-1);
            }
            foreach (var updateIndex in _updates)
                _updates.GetEntity(updateIndex).Del<UpdateCellsComponent>();
        }
    }
}
