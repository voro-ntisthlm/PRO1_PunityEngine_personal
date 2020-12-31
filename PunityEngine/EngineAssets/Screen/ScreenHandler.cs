using System;
using System.IO;
using Raylib_cs;

namespace PunityEngine
{
    class ScreenHandler
    {
        // Screen variables, will be set in pixels
        public int ScreenHeight = 720;
        public int ScreenWidth = 1280;
        public bool ScreenFullscreen = false;
        int targetFPS = 60;

        Texture2D screenFullscreen;

        // You can ignore the config file and hard code the screen resolution and title.
        public ScreenHandler(string _title, int _windowWidth, int _windowHeight, string _icon){

            Image icon = Raylib.LoadImage(_icon);
            
            Raylib.InitWindow(_windowWidth, _windowHeight, _title);
            Raylib.SetWindowIcon(icon);

            screenFullscreen = Raylib.LoadTexture(@"EngineAssets/icon.png");

            }

        // This will allow you to load the screen configuration from a file.
        public ScreenHandler(string _title ,string CONFIG_SCREEN, string _icon){

            // Load the window title.
            Image icon = Raylib.LoadImage(_icon);
            
            // This will attempt to load the screen configuration from the screen.cfg file
            try
            {
                string[] configLines = System.IO.File.ReadAllLines(CONFIG_SCREEN);


                // This will loop thorugh the file and depending on the "variable" it will assign the value to the corrosponding variable
                foreach (var config in configLines)
                {
                    string[] line = config.Split(":");

                    switch (line[0])
                    {
                        case "WIDTH":
                            int.TryParse(line[1], out ScreenWidth);
                            break;
                        case "HEIGHT":
                            int.TryParse(line[1], out ScreenHeight);
                            break;
                        case "FULLSCREEN":
                            ScreenFullscreen = Convert.ToBoolean(line[1]);
                            break;
                        case "TARGETFPS":
                            int.TryParse(line[1], out targetFPS);
                            Raylib.SetTargetFPS(targetFPS);
                            break;
                        default:
                        break;
                    }
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("ERROR WHEN LOADING SCREEN.CFG");    
            }


            // Starts the screen
            Raylib.InitWindow(ScreenWidth, ScreenHeight, _title);

            if(ScreenFullscreen){
                Raylib.ToggleFullscreen();
            }

            Raylib.SetWindowIcon(icon);

            screenFullscreen = Raylib.LoadTexture(@"EngineAssets/icon.png");
        }


        // This function will look at the current configuration of the window, and save it in the SCREEN.cfg file.
        // Will return a true if its successfully saved otherwise returns false.
        public bool SaveCurrentConfiguration(){
            try
            {
                // This will get the data needed.
                string[] savedConfig = {
                    "WIDTH:" + Raylib.GetScreenWidth(), 
                    "HEIGHT:" + Raylib.GetScreenHeight(), 
                    "FULLSCREEN:" + Raylib.IsWindowFullscreen(),
                    "TARGETFPS:" + targetFPS
                };

                File.WriteAllLines(Program.CONFIG_SCREEN, savedConfig);
                return true;   
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
