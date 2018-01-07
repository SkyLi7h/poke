using Microsoft.Xna.Framework.Graphics;

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

        public SpaceShipDesc(string spaceShipName, float maxSpeed, float speedRotation, double accelaration, double deceleration, Texture2D texture)
        {
            this.spaceShipName = spaceShipName;
            this.maxSpeed = maxSpeed;
            this.accelaration = accelaration;
            this.deceleration = deceleration;
            this.texture = texture;
            this.speedRotation = speedRotation;
        }

        public SpaceShipDesc(string spaceShipName, float maxSpeed, float speedRotation, double accelaration, double deceleration)
        {
            this.spaceShipName = spaceShipName;
            this.maxSpeed = maxSpeed;
            this.accelaration = accelaration;
            this.deceleration = deceleration;
            this.speedRotation = speedRotation;
        }
    }
}
