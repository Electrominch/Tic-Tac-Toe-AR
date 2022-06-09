using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using Leopotam.Ecs.Ui.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInstallSystem : IEcsInitSystem
{
    EcsWorld _world;

    public void Init()
    {
        _world.SendMessage(new BeginUINavigateComponent("MainMenu", 0.5f));
        _world.SendMessage(new ChangeBotComponent() { Target = Bot.Easy });
        _world.SendMessage(new UpdateMarkersEventComponent());
    }
}
