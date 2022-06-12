using Leopotam.Ecs.Game.Components;

namespace Leopotam.Ecs.Game.Systems
{
    public class GameInitSystem : IEcsInitSystem
    {
        EcsWorld _world = null;

        public void Init()
        {
            SetPlayers(Bridge.PlayMode == TicTacMode.Bot ? 1:2);
            //SetPlayers(0);
            SetGameConf();
            _world.NewEntity().Get<FieldComponent>();
            _world.SendMessage(new StartGameCycleComponent());
        }

        private void SetPlayers(int users)
        {
            for(int playerID = 0; playerID<2; playerID++)
            {
                var ent = _world.NewEntity();
                ent.Get<GamePlayerComponent>() = new GamePlayerComponent(playerID);
                if (users-- > 0)
                    ent.Get<UserComponent>();
                else
                    ent.Get<BotComponent>().BotDif = Bridge.BotDifficulty;

                ent.Get<PlayerGameStatComponent>();
            }
        }

        private void SetGameConf()
        {
            var ent = _world.NewEntity();
            ent.Get<GameConfComponent>().CellCount = 9;
            ent.Get<GameConfComponent>().TacMode = Bridge.PlayMode;
        }
    }
}