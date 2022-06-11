using Assets.Scenes.Game.GameCycle;
using Assets.Scenes.Game.GameCycle.Cell;
using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Game.Systems
{
    internal class CellSetupSystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<ImageObjectComponent, ImageObjectFoundedComponent> _founded = null;
        CellBehaivor _cellPrefab = null;
        EcsFilter<GameInfoComponent> _gi = null;

        public void Run()
        {
            foreach(var foundedIndex in _founded)
            {
                ref var foundedEntity = ref _founded.GetEntity(foundedIndex);//новая сущность
                foundedEntity.Del<ImageObjectFoundedComponent>();//снимаем с неё пометку нового объекта
                ref var imageObjectComponent = ref foundedEntity.Get<ImageObjectComponent>();//компонент трекинг-объекта
                
                var gridGroup = imageObjectComponent.View.LayoutGroup;//сетка

                int _cellCount = _gi.Get1(0).CellCount;
                int side = (int)Mathf.Sqrt(_cellCount);

                imageObjectComponent.Cells = new CellBehaivor[side][];
                for (int i = 0; i < imageObjectComponent.Cells.Length; i++)
                    imageObjectComponent.Cells[i] = new CellBehaivor[side];

                for(int y = 0; y < side; y++)
                    for(int x = 0; x < side; x++)
                    {
                        var cell = GameObject.Instantiate(_cellPrefab, gridGroup.transform);
                        cell.X = x;
                        cell.Y = y;
                        imageObjectComponent.Cells[y][x] = cell;
                    }
                CalcCellSize(gridGroup);//делаем квадрат из клеточек 
                _world.SendMessage(new UpdateCellsContentComponent());//обновляем новые клеточки
                _world.SendMessage(new UpdateCellsColorComponent());//обновляем новые клеточки
            }
        }

        private void CalcCellSize(GridLayoutGroup gridGroup)
        {
            var rect = gridGroup.GetComponent<RectTransform>().rect;
            var wigth = rect.width - gridGroup.padding.left - gridGroup.padding.right;
            var childCount = gridGroup.transform.childCount;
            var cellSize = wigth / Mathf.Sqrt(childCount);
            gridGroup.cellSize = new Vector2(cellSize, cellSize);
        }
    }
}
