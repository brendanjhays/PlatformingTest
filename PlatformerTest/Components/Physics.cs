using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace PlatformerTest
{
    class Physics
    {
        //Stores velocity of an entity in x and y directions
        public Vector2 velocity;
        
        //Modifier that affects the x velocity of entities, "smoothing effect"
        public float velocityMod;

        //Amount to default accelerate entitys' x velocity in air and on ground
        public float xAcceleration;
        public float xAirAcceleration;
        
        //Stores acceleration of an entity in x and y directions
        public Vector2 acceleration { get; set; }

        public Physics() 
        {
        }
    }
}
