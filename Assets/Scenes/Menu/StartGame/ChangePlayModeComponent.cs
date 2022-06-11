namespace Leopotam.Ecs.Menu.Components
{
    internal struct ChangePlayModeComponent
    {
        public TicTacMode TargetMode;

        public ChangePlayModeComponent(TicTacMode mode)
        {
            TargetMode = mode;
        }
    }
}
