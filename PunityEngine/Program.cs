using System;
using Raylib_cs;

namespace PunityEngine
{
    class Program
    {
        #region Path variables, will be moved into seprete file later
        public static string CONFIG_SCREEN = "./Data/Configuration/Screen.cfg";

        #endregion
        static void Main(string[] args)
        {
            ScreenHandler screenHandler = new ScreenHandler("PunityEngine", 1280, 720);
    
            screenHandler.SaveConfiguration();

            Texture2D logo = Raylib.LoadTextureFromImage(Raylib.LoadImage("EngineAssets/icon.png"));

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                Raylib.DrawTexture(logo, Raylib.GetScreenWidth()/2-90, Raylib.GetScreenHeight()/2-80, Color.WHITE);           
                Raylib.EndDrawing();
            }
           
        }
    }
}
