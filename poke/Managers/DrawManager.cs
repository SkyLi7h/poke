using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using poke.Models;

namespace poke.Managers
{
    class DrawManager
    {
        public SpriteBatch spriteBatch { get; set; }

        public void drawSpaceShip(SpaceShip spaceShip, float scale)
        {
            Vector2 origin = new Vector2(spaceShip.spaceShipDesc.texture.Width / 2, spaceShip.spaceShipDesc.texture.Height / 2);
            spriteBatch.Draw(spaceShip.spaceShipDesc.texture, spaceShip.positionActual, null, Color.White, (float)spaceShip.angle, origin, scale, SpriteEffects.None, 0);
        }

    }
}
