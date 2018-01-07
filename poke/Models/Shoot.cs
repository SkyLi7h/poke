using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poke.Models
{
    class Shoot
    {
        public Vector2 position { get; set; }
        public Vector2 origin { get; set; }
        public double speed { get; set; }
        public double angle { get; set; }
        public Texture2D texture { get; set; }

        public Shoot(Vector2 position, Vector2 origin, double speed, double angle, Texture2D texture)
        {
            this.position = position;
            this.origin = origin;
            this.speed = speed;
            this.angle = angle;
            this.texture = texture;
        }

    }
}
