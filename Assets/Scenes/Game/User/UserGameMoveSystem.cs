using Leopotam.Ecs.Game.Components;

namespace Leopotam.Ecs.Game.Systems
{
    internal class UserGameMoveSystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<UserGameMoveComponent> _moves = null;
        EcsFilter<GamePlayerComponent, UserComponent, PlayerTurnComponent> _userPlayers = null;

        public void Run()
        {
            foreach(var moveIndex in _moves)
            {
                var move = _moves.Get1(moveIndex);
                foreach(var pIndex in _userPlayers)
                {
                    _world.SendMessage(new GameMoveComponent(move.X, move.Y));
                }
                _moves.GetEntity(moveIndex).Del<UserGameMoveComponent>();
            }
        }
    }
}
