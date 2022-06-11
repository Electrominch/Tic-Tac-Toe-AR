using Leopotam.Ecs.Menu.UI.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

namespace Leopotam.Ecs.Menu.UI
{
    public class AddMarkerButton : MonoBehaviour
    {
        public void CreateMarker()
        {
            MarkersVault.AskNew();
        }
    }
}