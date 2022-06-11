using Leopotam.Ecs.Game.Components;

namespace Bots
{
    internal interface IBot
    {
        public (int, int) Move(PlayerFigure[][] field, PlayerFigure me);
    }
}
