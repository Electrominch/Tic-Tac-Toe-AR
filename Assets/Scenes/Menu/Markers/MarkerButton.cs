using Leopotam.Ecs.Game.Components;
using Leopotam.Ecs.Ui.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Voody.UniLeo;

public class MarkerButton : MonoBehaviour
{
    public string MarkerName { get; set; }
    [SerializeField] private Image _imgView;

    public void SetSprite(Sprite sprite)
    {
        _imgView.sprite = sprite;
    }

    public void DeleteThis()
    {
        MarkersVault.Remove(MarkerName);
        WorldHandler.GetWorld().SendMessage(new UpdateMarkersEventComponent());
        Destroy(gameObject);
    }

    public void PlayThis()
    {
        WorldHandler.GetWorld().SendMessage(new StartGameComponent(MarkersVault.LoadMarker(MarkerName)));
    }
}
