using System;
using System.Numerics;
using Raylib_cs;

namespace PunityEngine.Game.Entities
{
    public class Player : Entity
    {
        // This will be replaced when the networking goese into effect.
        bool isMultiplayer = false;

        public Player(){
            texture = Raylib.LoadTexture("EngineAssets/icon.png");
            ScaleToScreen(); //Inherited from the Entity class
        }

        public override void Draw()
        {
            Raylib.DrawTextureV(texture, Position, Color.WHITE);
        }

        public override void Update(){
            if (!isMultiplayer)
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
            {
                Position.Y -= 200 * Raylib.GetFrameTime();
            }
            if (Raylib.IsKeyDown(key: KeyboardKey.KEY_S))
            {
                Position.Y += 200 * Raylib.GetFrameTime();
            }
            if (Raylib.IsKeyDown(key: KeyboardKey.KEY_A))
            {
                Position.X -= 200 * Raylib.GetFrameTime();
            }
            if (Raylib.IsKeyDown(key: KeyboardKey.KEY_D))
            {
                Position.X += 200 * Raylib.GetFrameTime();
            }
        }
    }
}
