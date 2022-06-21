using Leopotam.Ecs.Game.UI;
using System;

[Serializable]
public struct ImageObjectComponent
{
    public ImageObjcetView View;
    public CellBehaivor[][] Cells;

    public void SetInteractable(bool b)
    {
        foreach (var row in Cells)
            foreach (var cell in row)
                cell.SetInteractable(b);
    }
}
