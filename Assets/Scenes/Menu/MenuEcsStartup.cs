using Leopotam.Ecs;
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
        [SerializeField] private EcsUiEmitter _menuEmitter;

        void Start () {
            Application.targetFrameRate = 60;
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
                
                .Add(new UISystem())
                .Add(new ChangeBotSystem())
                .Add(new BeginUINavigateSystem())
                .Add(new EndUINavigateSystem())
                .Inject(_uiView)
                .InjectUi(_menuEmitter)
                .Init ();
            _world.SendMessage(new BeginUINavigateComponent("MainMenu",0.5f));
            _world.SendMessage(new ChangeBotComponent() { Target = Bot.Easy });
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