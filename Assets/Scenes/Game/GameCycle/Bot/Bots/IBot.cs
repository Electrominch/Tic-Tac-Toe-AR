using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scenes.Game.GameCycle.Bot.Bots
{
    internal interface IBot
    {
        public (int, int) Move(PlayerFigure[][] field, PlayerFigure me);
    }
}
