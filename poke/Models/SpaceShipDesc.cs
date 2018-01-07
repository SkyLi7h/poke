using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace poke.Models
{
    public class SpaceShipDesc
    {
        public string spaceShipName { get; set; }
        public double maxSpeed { get; set; }
        public double speedRotation { get; set; } 
        public double accelaration { get; set; }
        public double deceleration { get; set; }
        public Texture2D texture { get; set; }
        public Vector2[] positionTurretList { get; set; }

        public SpaceShipDesc(string spaceShipName, float maxSpeed, float speedRotation, double accelaration, double deceleration, Vector2[] positionTurretList)
        {
            this.spaceShipName = spaceShipName;
            this.maxSpeed = maxSpeed;
            this.accelaration = accelaration;
            this.deceleration = deceleration;
            this.speedRotation = speedRotation;
            this.positionTurretList = positionTurretList;
        }
    }
}
