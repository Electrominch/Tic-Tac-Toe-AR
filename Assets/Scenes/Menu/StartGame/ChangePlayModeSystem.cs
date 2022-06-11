using Leopotam.Ecs;
using Leopotam.Ecs.Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Leopotam.Ecs.Game.Systems
{
    internal class ChangePlayModeSystem : IEcsRunSystem
    {
        EcsFilter<ChangePlayModeComponent> _change = null;
        EcsFilter<GameConfComponent, PlayModeComponent> _conf = null;

        public void Run()
        {
            if (_change.GetEntitiesCount() == 0)
                return;
            foreach (var i in _conf)
                _conf.Get2(2).Mode = _change.Get1(0).TargetMode;
            foreach (var i in _change)
                _change.GetEntity(i).Del<ChangePlayModeComponent>();
        }
    }
}
