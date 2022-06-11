using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scenes.Game.GameCycle.User
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
