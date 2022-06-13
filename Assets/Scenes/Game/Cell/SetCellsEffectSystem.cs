using Leopotam.Ecs.Game.UI.Components;
using System.Linq;
using UnityEngine;

namespace Leopotam.Ecs.Game.UI.Systems
{
    internal class SetCellsEffectSystem : IEcsRunSystem
    {
        EcsFilter<ImageObjectComponent> _imageObjects = null;
        EcsFilter<SetCellsEffectComponent> _event = null;

        public void Run()
        {
            foreach (var i in _event)
            {
                foreach (var imgIndex in _imageObjects)
                {
                    ref var imageObject = ref _imageObjects.Get1(imgIndex);
                    ref var e = ref _event.Get1(i);

                    var imageObjcetView = imageObject.View;
                    var line = imageObjcetView.WinLine;
                    line.gameObject.SetActive(e.DrawWinLine);
                    Vector2 cell1 = Vector3.zero;
                    Vector2 cell2 = Vector3.zero;

                    foreach (var cellsRow in imageObject.Cells)
                    {
                        foreach (var cell in cellsRow)
                        {
                            if (e.WinCells.Any(winC => winC.X == cell.X && winC.Y == cell.Y))
                            {

                            }
                            else
                            {
                                cell.SetContentAlpha(e.a);
                            }

                            if(e.DrawWinLine)
                            {
                                if (cell.X == e.WinCells[0].X && cell.Y == e.WinCells[0].Y)
                                    cell1 = cell.transform.localPosition;
                                else if (cell.X == e.WinCells.Last().X && cell.Y == e.WinCells.Last().Y)
                                    cell2 = cell.transform.localPosition;
                            }
                        }
                    }

                    if (e.DrawWinLine)
                    {
                        line.Draw(new Vector2[] { cell1, cell2 }, imageObject.View.LayoutGroup.cellSize.x);

                    }
                }
            }
        }


    }
}
