using UnityEngine;

namespace Leopotam.Ecs.Menu.Components
{
    internal struct StartGameComponent
    {
        public Texture2D Marker;

        public StartGameComponent(Texture2D markerName)
        {
            Marker = markerName;
        }
    }
}
