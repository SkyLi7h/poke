using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

public class SpaceShip
{
    int spaceShipId;
    int playerId;
    string playerName;
    SpaceShipDesc spaceShipDesc;
    object[] turret;
    int health;
    int shield;
    object[] cargo;
    Vector2 positionActual;

    public SpaceShip()
	{
	}
}
