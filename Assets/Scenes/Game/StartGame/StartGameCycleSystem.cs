using Leopotam.Ecs.Game.Components;
using Leopotam.Ecs.Game.UI.Components;
using System;
using System.Linq;

namespace Leopotam.Ecs.Game.Systems
{
    internal class StartGameCycleSystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<StartGameCycleComponent> _start = null;
        EcsFilter<GamePlayerComponent> _players = null;
        EcsFilter<FieldComponent> _field = null;
        EcsFilter<GameConfComponent> _gi = null;

        public void Run()
        {
            if (_start.GetEntitiesCount() == 0)
                return;
            SetUpField();
            RandomTurn();
            RandomFigures();
            foreach (var i in _start)
                _start.GetEntity(i).Del<StartGameCycleComponent>();
            _world.SendMessage(new UpdateAllUIComponent());
            _world.SendMessage(new SetRandomBackColorComponent());
            _world.SendMessage(new SetCellsEffectComponent() { a = 1f, WinCells = new CellXY[0], DrawWinLine = false });
        }

        private void RandomFigures()//случайное распределение фигурок
        {
            var rnd = UnityEngine.Random.Range(0, 2);
            _players.GetEntity(0).Replace(new FigureComponent(rnd==0?PlayerFigure.Crosses:PlayerFigure.Noughts));
            _players.GetEntity(1).Replace(new FigureComponent(rnd==1?PlayerFigure.Crosses:PlayerFigure.Noughts));
        }

        private void RandomTurn()//случайный игрок получает возможность ходить первым
        {
            int rndP = UnityEngine.Random.Range(0, _players.GetEntitiesCount());
            _players.GetEntity(rndP).Get<PlayerTurnComponent>();
        }

        private void SetUpField()
        {
            ref var field = ref _field.Get1(0);
            var side = (int)MathF.Sqrt(_gi.Get1(0).CellCount);
            field.Field = new PlayerFigure[side][];
            for (int i = 0; i < field.Field.Length; i++)
                field.Field[i] = Enumerable.Repeat(PlayerFigure.None, side).ToArray();
        }
    }
}
