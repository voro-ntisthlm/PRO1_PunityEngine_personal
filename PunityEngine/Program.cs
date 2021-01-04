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

            // To allow the esc button to be used as a pause button,
            // F12 have been set as the exit key.
            Raylib.SetExitKey(key: KeyboardKey.KEY_F12);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                // Default color if it is not overidden by a background in any stage.
                Raylib.ClearBackground(Color.BLANK);
                
                // This will actually draw the game.
                game.Draw();
                game.Update();
                
                Raylib.EndDrawing();

            }
            
            Raylib.CloseWindow();

            //When the game closes, it saves the config.
            screenHandler.SaveCurrentConfiguration();
           
        }
    }
}
