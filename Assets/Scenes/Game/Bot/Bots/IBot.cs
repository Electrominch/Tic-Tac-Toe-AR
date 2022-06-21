using Leopotam.Ecs.Game.Components;

namespace Bots
{
    internal interface IBot
    {
        public CellXY Move(PlayerFigure[][] field, PlayerFigure me);
    }
}
