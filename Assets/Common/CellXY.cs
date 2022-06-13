internal struct CellXY
{
    public int X;
    public int Y;

    public CellXY(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X};{Y})";
    }
}