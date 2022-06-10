using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scenes.Game.GameCycle.StartGame
{
    internal struct FigureComponent
    {
        public readonly PlayerFigure Figure;
        
        public FigureComponent(PlayerFigure figure)
        {
            Figure = figure;
        }
    }
}
