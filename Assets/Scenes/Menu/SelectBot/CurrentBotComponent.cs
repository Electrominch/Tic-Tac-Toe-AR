using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopotam.Ecs.Ui.Components
{
    internal struct CurrentBotComponent
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
