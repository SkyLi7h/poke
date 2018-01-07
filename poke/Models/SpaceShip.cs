using Microsoft.Xna.Framework;
using poke.GameTools;
using System.Collections.Generic;

namespace poke.Models
{
    public class SpaceShip
    {
        public int spaceShipId { get; set; }
        public int playerId { get; set; }
        public SpaceShipDesc spaceShipDesc { get; set; }
        public Turret[] turrets { get; set; }
        public FixeTurret[] fixeTurrets { get; set; }
        public double health { get; set; }
        public double shield { get; set; }
        public double speed { get; set; }
        public double rotation { get; set; }
        public double angle { get; set; }
        public Vector2 positionActual { get; set; }

        public SpaceShip(int spaceShipId, int playerId, SpaceShipDesc spaceShipDesc, Turret[] turrets, FixeTurret[] fixeTurrets, double health, double shield, double speed, double rotation, double angle, Vector2 positionActual)
        {
            this.spaceShipId = spaceShipId;
            this.playerId = playerId;
            this.spaceShipDesc = spaceShipDesc;
            this.turrets = turrets;
            this.fixeTurrets = fixeTurrets;
            this.health = health;
            this.shield = shield;
            this.speed = speed;
            this.rotation = rotation;
            this.angle = angle;
            this.positionActual = positionActual;

        }
    }
}
