namespace Leopotam.Ecs.Game.Components
{
    internal struct GameEndedComponent
    {
        public PlayerFigure WinnerFigure;
        public int WinnerID;
        public CellXY[] WinCells;

        public GameEndedComponent(int id, PlayerFigure fig, CellXY[] winCells)
        {
            WinnerID = id;
            WinnerFigure = fig;
            WinCells = winCells;
        }
    }
}
