using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Voody.UniLeo;

namespace Leopotam.Ecs.Ui.Components
{
    [Serializable]
    public struct UIPartComponent
    {
        public GameObject UIObject;
        public string PartName;
    }
}
