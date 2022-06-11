namespace Leopotam.Ecs.Game.Components
{
    internal struct GameMoveComponent
    {
        public readonly int X;
        public readonly int Y;

        public GameMoveComponent(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
