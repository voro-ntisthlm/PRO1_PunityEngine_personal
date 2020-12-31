using System;
using System.Numerics;
using Raylib_cs;

namespace PunityEngine.Game.Entities
{
    public class Player : Entity
    {
        bool isMultiplayer = false; //This will be replaced when the networking goese into effect.

        //public new Vector2 Position = new Vector2();

        public Player(){
            texture = Raylib.LoadTexture("EngineAssets/icon.png");
            ScaleToScreen(); //Inherited from the Entity class
        }

        public override void Draw()
        {
            Raylib.DrawTextureV(texture, Position, Color.WHITE);
            base.Draw();
        }

        public override void Update(){
            if (!isMultiplayer)
            {
                UserInput();
            }
        }

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
