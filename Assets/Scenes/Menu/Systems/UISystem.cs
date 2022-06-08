using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using Leopotam.Ecs.Ui.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : IEcsInitSystem
{
    EcsWorld _world;
    MainSceneUIView _ui;

    public void Init()
    {
        var menu = _ui.MenuPart;
        menu.SelectBot.onClick.AddListener(() => 
        {
            _world.SendMessage(new BeginUINavigateComponent("SelectBot"));
        });
        menu.TwoPlayers.onClick.AddListener(() => { });
        menu.Settings.onClick.AddListener(() =>
        {
            _world.SendMessage(new BeginUINavigateComponent("Settings"));
        });

        var selectBotPart = _ui.SelectBotPart;
        selectBotPart.BackToMenu.onClick.AddListener(() =>
        {
            _world.SendMessage(new BeginUINavigateComponent("MainMenu"));
        });
        selectBotPart.EasyBot.onClick.AddListener(()=> _world.SendMessage(new ChangeBotComponent() { Target = Bot.Easy }));
        selectBotPart.NormalBot.onClick.AddListener(()=> _world.SendMessage(new ChangeBotComponent() { Target = Bot.Normal }));
        selectBotPart.HardBot.onClick.AddListener(()=> _world.SendMessage(new ChangeBotComponent() { Target = Bot.Hard }));
        selectBotPart.Tournament.onClick.AddListener(()=> _world.SendMessage(new ChangeBotComponent() { Target = Bot.Tournament }));

        var settingsPart = _ui.SettingsPart;
        settingsPart.BackToMenu.onClick.AddListener(()=>
        {
            _world.SendMessage(new BeginUINavigateComponent("MainMenu"));
        });
    }

    public void Run()
    {
        //foreach (var idx in _clickEvents)
        //{
        //    ref EcsUiClickEvent data = ref _clickEvents.Get1(idx);
        //    BeginChangeUIPartComponent mes = new BeginChangeUIPartComponent() { Delay = 0.1f };
        //    switch (data.WidgetName)
        //    {
        //        case "SelectBotButton":
        //            {
        //                mes.PartName = "SelectBot";
        //                break;
        //            }
        //        case "BackToMenuButton":
        //            {
        //                mes.PartName = "MainMenu";
        //                break;
        //            }
        //        case "SettingsButton":
        //            {
        //                mes.PartName = "Settings";
        //                break;
        //            }
        //    }
        //    if(string.IsNullOrEmpty(mes.PartName) == false)
        //        _world.SendMessage(mes);
        //}
    }
}
