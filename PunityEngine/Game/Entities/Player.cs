using System;
using System.Numerics;
using Raylib_cs;
using PunityEngine.Engine.Network;

namespace PunityEngine.Game.Entities
{
    public class Player : Entity
    {
        public Player(){
            texture = Raylib.LoadTexture("Data/icon.png");
            ScaleToScreen(); //Inherited from the Entity class
        }

        public override void Draw()
        {
            Raylib.DrawTextureV(texture, Position, Color.WHITE);
        }

        public override void Update(){
            if (!Client.isMultiplayer)
            {
                UserInput();
            }
            else
            {
                // Parse move instructions from the multiplayer component here...
            }
        }

        // TODO: Create a better user input system.
        void UserInput(){
            if (Raylib.IsKeyDown(key: KeyboardKey.KEY_W))
                Position.Y -= 200 * Raylib.GetFrameTime();
            if (Raylib.IsKeyDown(key: KeyboardKey.KEY_S))
                Position.Y += 200 * Raylib.GetFrameTime();
            if (Raylib.IsKeyDown(key: KeyboardKey.KEY_A))
                Position.X -= 200 * Raylib.GetFrameTime();
            if (Raylib.IsKeyDown(key: KeyboardKey.KEY_D))
                Position.X += 200 * Raylib.GetFrameTime();
        }
    }
}
