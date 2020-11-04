using System;
using System.IO;
using Raylib_cs;

namespace PunityEngine
{
    class ScreenHandler
    {
        //Screen variables, will be set in pixels
        public int screenHeight = 720;
        public int screenWidth = 1280;
        public bool screenFullscreen = false;

        //You can ignore the config file and hard code the screen resolution and title.
        public ScreenHandler(string _title, int _windowWidth, int _windowHeight, string _icon){

            Image icon = Raylib.LoadImage(_icon);

            Raylib.InitWindow(_windowWidth, _windowHeight, _title);
            Raylib.SetWindowIcon(icon);
        }

        //This will allow you to load the screen configuration from a file.
        public ScreenHandler(string _title ,string CONFIG_SCREEN, string _icon){

            //Load the window title.
            Image icon = Raylib.LoadImage(_icon);

            //This will attempt to load the screen configuration from the screen.cfg file
            try
            {
                string[] configLines = System.IO.File.ReadAllLines(CONFIG_SCREEN);


                //This will loop thorugh the file and depending on the "variable" it will assign the value to the corrosponding variable
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
                        default:
                        break;
                    }
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("ERROR WHEN LOADING SCREEN.CFG");    
            }


            //Starts the screen
            Raylib.InitWindow(screenWidth, screenHeight, _title);

            if(screenFullscreen){
                Raylib.ToggleFullscreen();
            }

            Raylib.SetWindowIcon(icon);
        }

        //This function will look at the current configuration of the window, and save it in the SCREEN.cfg file.
        //Will return a true if its successfully saved otherwise returns false.
        public bool SaveCurrentConfiguration(){
            try
            {
                //This will get the data needed.
                string[] savedConfig = {
                    "WIDTH:" + Raylib.GetScreenWidth(), 
                    "HEIGHT:" + Raylib.GetScreenHeight(), 
                    "FULLSCREEN:" + Raylib.IsWindowFullscreen()
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
