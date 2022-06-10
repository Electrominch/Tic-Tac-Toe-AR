﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopotam.Ecs.Game.Components
{
    internal struct ChangePlayModeComponent
    {
        public PlayMode TargetMode;

        public ChangePlayModeComponent(PlayMode mode)
        {
            TargetMode = mode;
        }
    }

    
}