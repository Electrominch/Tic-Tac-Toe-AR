using Leopotam.Ecs.Ui.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

public class AddMarkerButton : MonoBehaviour
{
    public void CreateMarker()
    {
        MarkersVault.AskNew();
	}
}
