using Leopotam.Ecs;
using Leopotam.Ecs.Game.Components;
using Leopotam.Ecs.Ui.Components;
using Leopotam.Ecs.Ui.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInstallSystem : IEcsInitSystem
{
    EcsWorld _world = null;

    public void Init()
    {
        SetGameConf();
        _world.SendMessage(new BeginUINavigateComponent("MainMenu"));
        _world.SendMessage(new UpdateMarkersEventComponent());
    }

    private void SetGameConf()
    {
        var ent = _world.NewEntity();
        ent.Get<GameConfComponent>();
        ent.Get<BotComponent>();
        ent.Get<PlayModeComponent>();
        _world.SendMessage(new ChangeBotComponent() { Target = Bot.Easy });
    }
}
