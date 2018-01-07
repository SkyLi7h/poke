using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using poke.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using poke.GameTools;

namespace poke.Managers
{
    class UpdateManager
    {

        double angle;
        double dX;
        double dY;
        double laserSpeed = 20;
        TimeTools timeTools = new TimeTools();

        public void updateSpaceShip(SpaceShip spaceShip, int gameTimeMillis)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                spaceShip.speed += spaceShip.spaceShipDesc.accelaration * (((double)(gameTimeMillis)) / 1000);

                if (spaceShip.speed > spaceShip.spaceShipDesc.maxSpeed)
                    spaceShip.speed = spaceShip.spaceShipDesc.maxSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                spaceShip.speed -= spaceShip.spaceShipDesc.deceleration * (((double)(gameTimeMillis)) / 1000);

                if (spaceShip.speed < 0)
                    spaceShip.speed = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                spaceShip.rotation -= spaceShip.spaceShipDesc.speedRotation;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                spaceShip.rotation += spaceShip.spaceShipDesc.speedRotation;
            }           

            angle = (float)(2 * Math.PI * (spaceShip.rotation / 360));

            dX = (float)(spaceShip.speed * Math.Sin(angle) * -1);
            dY = (float)(spaceShip.speed * Math.Cos(angle));

            Vector2 positionActual = spaceShip.positionActual;

            positionActual.X -= (float)dX;
            positionActual.Y -= (float)dY;

            spaceShip.angle = angle;
            spaceShip.positionActual = positionActual;

            Console.WriteLine(angle);

        }

        public void addShoot(SpaceShip spaceShip, List<Shoot> shootList, Texture2D texture)
        {
                for(var i = 0; i < spaceShip.fixeTurrets.Length; i++)
                {
                    if (spaceShip.fixeTurrets[i] != null)
                    {
                        if (timeTools.CurrentTimeMillis() >= spaceShip.fixeTurrets[i].lastFired + (long)(spaceShip.fixeTurrets[i].fireRate * 1000))
                        {
                            Vector2 origin = new Vector2(spaceShip.spaceShipDesc.positionTurretList[i].X, spaceShip.spaceShipDesc.positionTurretList[i].Y);
                            Vector2 initPositionShoot = new Vector2(spaceShip.positionActual.X, spaceShip.positionActual.Y);

                            Shoot shoot = new Shoot(initPositionShoot, origin, laserSpeed, spaceShip.angle, texture);
                            spaceShip.fixeTurrets[i].lastFired = timeTools.CurrentTimeMillis();
                            shootList.Add(shoot);
                        }

                    }                                     
                }         
        }

        public void updateShoot(List<Shoot> shootList, int gameTimeMillis)
        {
            foreach (Shoot shoot in shootList)
            {
                dX = (float)(shoot.speed * Math.Sin(shoot.angle) * -1);
                dY = (float)(shoot.speed * Math.Cos(shoot.angle));

                Vector2 position = shoot.position;

                position.X -= (float)dX;
                position.Y -= (float)dY;

                shoot.position = position;
            }
        }

    }
}
