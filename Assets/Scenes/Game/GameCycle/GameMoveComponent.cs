using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.Game.GameCycle
{
    internal struct GameMoveComponent
    {
        public readonly int X;
        public readonly int Y;

        public GameMoveComponent(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
