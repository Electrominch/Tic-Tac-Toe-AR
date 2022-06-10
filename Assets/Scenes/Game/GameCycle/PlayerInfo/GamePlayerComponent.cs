﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
