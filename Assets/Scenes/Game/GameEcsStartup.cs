using Leopotam.Ecs.Common.SceneNavigate;
using Leopotam.Ecs.Game.Components;
using Leopotam.Ecs.Game.Systems;
using Leopotam.Ecs.Game.UI;
using UnityEngine;
using Voody.UniLeo;

namespace Leopotam.Ecs.Game
{
    sealed class GameEcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;
        [SerializeField] GameUIView _ui;
        [SerializeField] CellBehaivor _cellPrefab;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            WorldHandler.Init (_world);
            _systems
                .ConvertScene()
                .Add(new GameInitSystem())
                .Add(new GameUIInitSystem())
                .Add(new SceneNavigateSystem())

                .Add(new CellSetupSystem())
                .Add(new UserGameMoveSystem())
                .Add(new BotGameMoveSystem())
                .Add(new StartGameCycleSystem())
                .Add(new GameCycleSystem())
                .Add(new UpdateCellsContentSystem())
                .Add(new UpdateCellsColorSystem())

                .OneFrame<UpdateCellsContentComponent>()
                .OneFrame<UpdateCellsColorComponent>()
                .Inject(_ui)
                .Inject(_cellPrefab)
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