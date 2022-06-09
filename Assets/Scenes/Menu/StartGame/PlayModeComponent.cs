using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopotam.Ecs.Game.Components
{
    internal struct PlayModeComponent
    {
        public PlayMode Mode;
    }

    public enum PlayMode
    {
        Bot,
        TwoPlayers,
    }
}
