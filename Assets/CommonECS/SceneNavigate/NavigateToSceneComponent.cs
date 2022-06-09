using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopotam.Ecs.Common.SceneNavigate
{
    internal struct NavigateToSceneComponent
    {
        public string SceneName;

        public NavigateToSceneComponent(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}
