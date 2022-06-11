using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopotam.Ecs.Game.Components
{
    internal struct UserGameMoveComponent
    {
        public int X;
        public int Y;

        public UserGameMoveComponent(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
