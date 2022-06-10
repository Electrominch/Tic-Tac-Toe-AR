using Leopotam.Ecs;
using Leopotam.Ecs.Common.SceneNavigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Leopotam.Ecs.Game.UI
{
    internal class GameUIInitSystem : IEcsInitSystem
    {
        EcsWorld _world = null;
        GameUIView _ui = null;

        public void Init()
        {
            _ui.BackToMenuButton.onClick.AddListener(() => _world.SendMessage(new NavigateToSceneComponent("Menu")));
        }
    }
}
