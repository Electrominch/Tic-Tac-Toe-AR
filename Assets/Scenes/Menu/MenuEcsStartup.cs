using Leopotam.Ecs;
using Leopotam.Ecs.Common.SceneNavigate;
using Leopotam.Ecs.Game.Systems;
using Leopotam.Ecs.Ui.Components;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
using UnityEngine.UI;
using Voody.UniLeo;

namespace Menu {
    sealed class MenuEcsStartup : MonoBehaviour {
        private EcsWorld _world;
        private EcsSystems _systems;
        [SerializeField] private MainSceneUIView _uiView;

        void Start () {
            //Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            // void can be switched to IEnumerator for support coroutines.

            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems.ConvertScene();
            _systems
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())

                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()

                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                
                .Add(new MenuUIInitSystem())
                .Add(new MenuInstallSystem())
                .Add(new UpdateMarkersSystem())
                .Add(new ChangeBotSystem())
                .Add(new BeginUINavigateSystem())
                .Add(new EndUINavigateSystem())
                .Add(new ChangePlayModeSystem())
                .Add(new StartGameSystem())
                .Add(new SceneNavigateSystem())
                .Inject(_uiView)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}