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
            //Initilizes the screenHandler
            ScreenHandler screenHandler = new ScreenHandler("Punity", CONFIG_SCREEN, "EngineAssets/icon.png");
            
            
            //This will initialise the game
            GameHandler game = new GameHandler();

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                game.Update();
                Raylib.EndDrawing();

            }
            
            Raylib.CloseWindow();
            //When the game closes, it saves the config.
            screenHandler.SaveCurrentConfiguration();
           
        }
    }
}
