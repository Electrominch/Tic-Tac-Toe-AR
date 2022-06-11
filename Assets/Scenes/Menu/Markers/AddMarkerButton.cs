using UnityEngine;

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