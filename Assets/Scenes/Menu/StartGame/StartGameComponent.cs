using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Leopotam.Ecs.Game.Components
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
