namespace Leopotam.Ecs.Game.Components
{
    internal struct GamePlayerComponent
    {
        public readonly int PlayerID;
        public GamePlayerComponent(int _p)
        {
            PlayerID = _p;
        }
    }
}
