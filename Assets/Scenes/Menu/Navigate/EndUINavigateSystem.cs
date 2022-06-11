using Leopotam.Ecs;
using Leopotam.Ecs.Menu.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Leopotam.Ecs.Menu.UI.Systems
{
    internal class EndUINavigateSystem : IEcsRunSystem
    {
        EcsFilter<UIPartComponent> _uiParts = null;
        EcsFilter<EndUINavigateComponent> _change = null;

        public void Run()
        {
            if(_change.GetEntitiesCount() > 0)
            {
                ref var needUIPart = ref _change.Get1(0);
                foreach(var i in _uiParts)
                {
                    ref var ui = ref _uiParts.Get1(i);
                    if (ui.PartName == needUIPart.PartName)
                        ui.UIObject.SetActive(true);
                    else
                        ui.UIObject.SetActive(false);
                }
                foreach (var i in _change)
                    _change.GetEntity(i).Destroy();
            }
        }
    }
}
