using System;
using System.IO;
using Raylib_cs;

namespace PunityEngine
{
    static class ScreenHandler
    {
        // Screen variables, will be set in pixels
        static public int    screenHeight     = 720;
        static public int    screenWidth      = 1280;
        static public bool   screenFullscreen = false;
        static public int    targetFPS        = 60;
        static public string title            = "Punity Game";
        static public string iconPath         = "";

        // This will allow you to load the screen configuration from a file.
        static public void Init(string CONFIG_SCREEN){
            // This will attempt to load the screen configuration from the screen.cfg file
            try
            {
                string[] configLines = System.IO.File.ReadAllLines(CONFIG_SCREEN);

                // This will loop thorugh the file and depending on the "variable" 
                // it will assign the value to the corresponding variable
                foreach (var config in configLines)
                {
                    string[] line = config.Split(":");

                    switch (line[0])
                    {
                        case "WIDTH":
                            int.TryParse(line[1], out screenWidth);
                            break;
                        case "HEIGHT":
                            int.TryParse(line[1], out screenHeight);
                            break;
                        case "FULLSCREEN":
                            screenFullscreen = Convert.ToBoolean(line[1]);
                            break;
                        case "TARGETFPS":
                            int.TryParse(line[1], out targetFPS);
                            Raylib.SetTargetFPS(targetFPS);
                            break;
                        case "ICON":
                            iconPath = "./Data/" + line[1];
                            break;
                        case "TITLE":
                            title = line[1];
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
            Raylib.InitWindow(screenWidth, screenHeight, title);

            if(screenFullscreen){
                Raylib.ToggleFullscreen();
            }

            // Load the window icon and apply it.
            Image icon = Raylib.LoadImage(iconPath);
            Raylib.SetWindowIcon(icon);
        }


        // This function will look at the current configuration of the window, and save it in the SCREEN.cfg file.
        // Will return a true if its successfully saved otherwise returns false.
        static public bool SaveCurrentConfiguration(){
            try
            {
                // This will get the data needed.
                string[] savedConfig = {
                    "WIDTH:" + Raylib.GetScreenWidth(), 
                    "HEIGHT:" + Raylib.GetScreenHeight(), 
                    "FULLSCREEN:" + Raylib.IsWindowFullscreen(),
                    "TARGETFPS:" + targetFPS
                };

                // Write the data to the cfg file.
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
