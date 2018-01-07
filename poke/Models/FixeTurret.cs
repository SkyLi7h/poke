using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poke.Models
{
    public class FixeTurret : Item
    {
        public double dammage { get; set; }
        public double fireRate { get; set; }
        public long lastFired { get; set; }

        public FixeTurret(string name, string description, double weight, double dammage, double fireRate, int lastFired) : base(name, description, weight)
        {
            this.dammage = dammage;
            this.fireRate = fireRate;
            this.lastFired = lastFired;
        }
    }

    
}
