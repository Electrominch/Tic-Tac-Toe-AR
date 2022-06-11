using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopotam.Ecs.Game.Components
{
    internal struct BotComponent
    {
        public Bot BotDif;
    }

    public enum Bot
    {
        Easy,
        Normal,
        Hard,
        Tournament
    }
}
