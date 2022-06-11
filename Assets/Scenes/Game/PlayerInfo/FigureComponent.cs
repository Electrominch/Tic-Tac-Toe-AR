namespace Leopotam.Ecs.Game.Components
{
    internal struct FigureComponent
    {
        public readonly PlayerFigure Figure;
        
        public FigureComponent(PlayerFigure figure)
        {
            Figure = figure;
        }
    }

    internal enum PlayerFigure
    {
        None = 0,
        Crosses = 1,
        Noughts = 2,
    }
}
