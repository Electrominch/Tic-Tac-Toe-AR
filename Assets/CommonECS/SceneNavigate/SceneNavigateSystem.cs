using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Leopotam.Ecs.Common.SceneNavigate
{
    internal class SceneNavigateSystem : IEcsRunSystem
    {
        EcsFilter<NavigateToSceneComponent> _nav = null;
        ISceneUIView _ui = null;

        public void Run()
        {
            if (_nav.GetEntitiesCount() == 0)
                return;
            string sceneName = _nav.Get1(0).SceneName;
            foreach (var i in _nav)
                _nav.GetEntity(i).Del<NavigateToSceneComponent>();
            _ui.GetBlackout().Black(()=>SceneManager.LoadScene(sceneName));
        }
    }
}
