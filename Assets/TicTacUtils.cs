using Leopotam.Ecs.Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static class TicTacUtils
{
    public static bool CheckEndOfGame(PlayerFigure[][] field, int lineForWin, out PlayerFigure winFigure, out CellXY[] winCells)
    {
        CellStat[][] checkTable = new CellStat[field.Length][];
        CellStat idle = new CellStat(1, 1, 1, 1);
        for (int i = 0; i < checkTable.Length; i++)
            checkTable[i] = Enumerable.Repeat(idle, field[i].Length).ToArray();
        bool fullField = true;
        for (int y = 0; y < field.Length; y++)
            for (int x = 0; x < field[y].Length; x++)
            {
                var cur = field[y][x];
                if (cur == PlayerFigure.None)
                {
                    fullField = false;
                    continue;
                }

                int lx = x - 1;
                int uy = y - 1;
                if (lx >= 0)//проверка слева
                {
                    if (field[y][lx] == cur)//проврка на этой же высоте
                        checkTable[y][x].EqualsLeft = checkTable[y][lx].EqualsLeft + 1;
                    if (uy >= 0 && field[uy][lx] == cur)//проврка выше
                        checkTable[y][x].EqualsTopLeft = checkTable[uy][lx].EqualsTopLeft + 1;
                }
                int rx = x + 1;
                if (uy >= 0) // проверка сверху
                {
                    var up = field[uy];
                    if (up[x] == cur)
                        checkTable[y][x].EqualsTop = checkTable[uy][x].EqualsTop + 1;
                    if (rx < up.Length && up[rx] == cur)
                        checkTable[y][x].EqualsTopRight = checkTable[uy][rx].EqualsTopRight + 1;
                }

                if (checkTable[y][x].Win(lineForWin, new CellXY(x, y), out winCells))
                {
                    winFigure = field[y][x];
                    return true;
                }
            }
        winFigure = PlayerFigure.None;
        winCells = new CellXY[0];
        return fullField;
    }

    public static CellStat[][] CreateTable(PlayerFigure[][] field)
    {
        CellStat[][] checkTable = new CellStat[field.Length][];
        CellStat idle = new CellStat(1, 1, 1, 1);
        for (int i = 0; i < checkTable.Length; i++)
            checkTable[i] = Enumerable.Repeat(idle, field[i].Length).ToArray();
        for (int y = 0; y < field.Length; y++)
            for (int x = 0; x < field[y].Length; x++)
            {
                var cur = field[y][x];
                if (cur == PlayerFigure.None)
                {
                    continue;
                }

                int lx = x - 1;
                int uy = y - 1;
                if (lx >= 0)//проверка слева
                {
                    if (field[y][lx] == cur)//проврка на этой же высоте
                        checkTable[y][x].EqualsLeft = checkTable[y][lx].EqualsLeft + 1;
                    if (uy >= 0 && field[uy][lx] == cur)//проврка выше
                        checkTable[y][x].EqualsTopLeft = checkTable[uy][lx].EqualsTopLeft + 1;
                }
                int rx = x + 1;
                if (uy >= 0) // проверка сверху
                {
                    var up = field[uy];
                    if (up[x] == cur)
                        checkTable[y][x].EqualsTop = checkTable[uy][x].EqualsTop + 1;
                    if (rx < up.Length && up[rx] == cur)
                        checkTable[y][x].EqualsTopRight = checkTable[uy][rx].EqualsTopRight + 1;
                }
            }
        return checkTable;
    }

    public struct CellStat
    {
        public int EqualsLeft;
        public int EqualsTopLeft;
        public int EqualsTop;
        public int EqualsTopRight;

        public CellStat(int l, int tl, int t, int tr)
        {
            EqualsLeft = l;
            EqualsTopLeft = tl;
            EqualsTop = t;
            EqualsTopRight = tr;
        }

        public bool Win(int length)
        {
            if (EqualsLeft >= length)
                return true;
            else if (EqualsTopLeft >= length)
                return true;
            else if (EqualsTop >= length)
                return true;
            else if (EqualsTopRight >= length)
                return true;
            return false;
        }

        public bool Win(int length, CellXY curCell, out CellXY[] winCells)
        {
            List<CellXY> cells = new List<CellXY>();
            bool win = false;
            if (EqualsLeft >= length)
            {
                while (length-- > 0)
                {
                    cells.Add(curCell);
                    curCell.X--;
                }
                win = true;
            }
            else if (EqualsTopLeft >= length)
            {
                while (length-- > 0)
                {
                    cells.Add(curCell);
                    curCell.X--;
                    curCell.Y--;
                }
                win = true;
            }
            else if (EqualsTop >= length)
            {
                while (length-- > 0)
                {
                    cells.Add(curCell);
                    curCell.Y--;
                }
                win = true;
            }
            else if (EqualsTopRight >= length)
            {
                while (length-- > 0)
                {
                    cells.Add(curCell);
                    curCell.X++;
                    curCell.Y--;
                }
                win = true;
            }

            if (win)
            {
                winCells = cells.ToArray();
                return true;
            }

            winCells = new CellXY[0];
            return false;
        }

        public override string ToString()
        {
            return $"[{EqualsLeft}, {EqualsTopLeft}, {EqualsTop}, {EqualsTopRight}]";
        }
    }

    public static List<CellXY> EmptyCells(PlayerFigure[][] field)
    {
        List<CellXY> emptyCells = new List<CellXY>();
        for (int y = 0; y < field.Length; y++)
            for (int x = 0; x < field[y].Length; x++)
                if (field[y][x] == PlayerFigure.None)
                    emptyCells.Add(new CellXY(x, y));
        return emptyCells;
    }
}