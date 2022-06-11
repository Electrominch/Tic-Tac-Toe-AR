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
