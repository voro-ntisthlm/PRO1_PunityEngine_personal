using System;
using Raylib_cs;
using System.Timers;

namespace PunityEngine
{
    class Program
    {
        #region Path variables, will be moved into seprete file later
        public static string CONFIG_SCREEN = "./Data/Configuration/Screen.cfg";

        #endregion

        // This timer will be used to run the update function at the tick speed.
        static float tickTimerMaxValue = 0.025f;
        static float tickTimer = tickTimerMaxValue;

        static void Main(string[] args)
        {
            // Initilizes the screenHandler
            ScreenHandler.Init(CONFIG_SCREEN);

            // To allow the esc button to be used as a pause button,
            // F12 have been set as the exit key.
            Raylib.SetExitKey(key: KeyboardKey.KEY_F12);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                // Default color if it is not overidden by a background in any stage.
                Raylib.ClearBackground(Color.BLANK);
                
                // GameHandler is a static class.
                GameHandler.Draw();
                GameHandler.Update();

                /*
                // This will run the update function 20 times a second, instead of every single frame.
                // NOTE: this solution was mainly taken from the C# refrences.
 
                tickTimer -= Raylib.GetFrameTime();
                if (tickTimer < 0)
                {
                    game.Update();

                    // Resets the timer.
                    tickTimer = tickTimerMaxValue;
                }
                */

                Raylib.EndDrawing();
            }
            
            Raylib.CloseWindow();

            // When the game closes, it saves the config.
            // ScreenHandler.SaveCurrentConfiguration();
           
        }
    }
}
