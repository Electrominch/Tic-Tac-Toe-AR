namespace Leopotam.Ecs.Game.Components
{
    internal struct GameEndedComponent
    {
        public PlayerFigure WinnerFigure;
        public int WinnerID;

        public GameEndedComponent(int id, PlayerFigure fig)
        {
            WinnerID = id;
            WinnerFigure = fig;
        }
    }
}
