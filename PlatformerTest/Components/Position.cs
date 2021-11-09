using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace PlatformerTest
{
    class Position
    {
        //Stores position for x and y coordinates
        public Vector2 position { get; set; }

        public Position(Vector2 initial)
        {
            position = initial;
        }

    }
}
