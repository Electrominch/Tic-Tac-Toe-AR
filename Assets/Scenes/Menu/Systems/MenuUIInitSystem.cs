using Leopotam.Ecs.Game.Components;
using Leopotam.Ecs.Menu.Components;
using Leopotam.Ecs.Menu.UI.Components;

namespace Leopotam.Ecs.Menu.UI
{
    public class MenuUIInitSystem : IEcsInitSystem
    {
        EcsWorld _world = null;
        MainSceneUIView _ui = null;

        public void Init()
        {
            var menu = _ui.MenuPart;
            menu.SelectBot.onClick.AddListener(() =>
            {
                _world.SendMessage(new ChangePlayModeComponent(TicTacMode.Bot));
                _world.SendMessage(new BeginUINavigateComponent("SelectBot"));
            });
            menu.TwoPlayers.onClick.AddListener(() =>
            {
                _world.SendMessage(new ChangePlayModeComponent(TicTacMode.TwoPlayers));
                _world.SendMessage(new BeginUINavigateComponent("SelectMarker"));
            });
            menu.Settings.onClick.AddListener(() => _world.SendMessage(new BeginUINavigateComponent("Settings")));

            var selectBotPart = _ui.SelectBotPart;
            selectBotPart.BackToMenu.onClick.AddListener(() => _world.SendMessage(new BeginUINavigateComponent("MainMenu")));
            selectBotPart.EasyBot.onClick.AddListener(() => _world.SendMessage(new ChangeBotComponent() { Target = Bot.Easy }));
            selectBotPart.NormalBot.onClick.AddListener(() => _world.SendMessage(new ChangeBotComponent() { Target = Bot.Normal }));
            selectBotPart.HardBot.onClick.AddListener(() => _world.SendMessage(new ChangeBotComponent() { Target = Bot.Hard }));
            selectBotPart.Tournament.onClick.AddListener(() => _world.SendMessage(new ChangeBotComponent() { Target = Bot.Tournament }));
            selectBotPart.PlayWithBot.onClick.AddListener(() => _world.SendMessage(new BeginUINavigateComponent("SelectMarker")));

            var settingsPart = _ui.SettingsPart;
            settingsPart.BackToMenu.onClick.AddListener(() => _world.SendMessage(new BeginUINavigateComponent("MainMenu")));

            var selectMarkerPart = _ui.MarkerPart;
            selectMarkerPart.BackToMenu.onClick.AddListener(() => _world.SendMessage(new BeginUINavigateComponent("MainMenu")));
        }
    }

}