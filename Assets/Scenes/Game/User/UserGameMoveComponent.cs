namespace Leopotam.Ecs.Game.Components
{
    internal struct UserGameMoveComponent
    {
        public int X;
        public int Y;

        public UserGameMoveComponent(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
