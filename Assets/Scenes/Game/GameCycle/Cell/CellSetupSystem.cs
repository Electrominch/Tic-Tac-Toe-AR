using Assets.Scenes.Game.GameCycle.Cell;
using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.Game.Systems
{
    internal class CellSetupSystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<ImageObjectComponent, ImageObjectFoundedComponent> _founded = null;
        CellBehaivor _cellPrefab = null;

        public void Run()
        {
            foreach(var i in _founded)
            {
                Debug.Log("Cells...");
                var ImageObjectView = _founded.Get1(i).View;
                var glg = ImageObjectView.LayoutGroup;
                var rect = glg.GetComponent<RectTransform>().rect;
                var transform = glg.transform; //для дочерних объектов
                int _cellCount = 9;
                int side = (int)Mathf.Sqrt(_cellCount);
                for(int y = 0; y < side; y++)
                    for(int x = 0; x < side; x++)
                    {
                        var cell = GameObject.Instantiate(_cellPrefab, transform);
                        cell.X = x;
                        cell.Y = y;
                    }
                var wigth = rect.width - glg.padding.left - glg.padding.right;
                var childCount = transform.childCount;
                var cellSize = wigth / Mathf.Sqrt(childCount);
                glg.cellSize = new Vector2(cellSize, cellSize);

                _founded.GetEntity(i).Del<ImageObjectFoundedComponent>();
                _world.SendMessage(new UpdateCellsComponent());
            }
        }
    }
}
