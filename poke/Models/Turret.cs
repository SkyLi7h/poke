using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poke.Models
{
    public class Turret: Item
    {
        double dammage { get; set; }
        double fireRate { get; set; }
        long lastFired { get; set; }
        Texture2D texture { get; set; }
        double rotation { get; set; }
        double angle { get; set; }

        public Turret(string name, string description, double weight, double dammage, double fireRate, int lastFired, Texture2D texture, double rotation, double angle) : base(name, description, weight)
        {
            this.dammage = dammage;
            this.fireRate = fireRate;
            this.lastFired = lastFired;
            this.texture = texture;
            this.rotation = rotation;
            this.angle = angle;
        }
    }
}
