using System;
using System.IO;
using Raylib_cs;

namespace PunityEngine
{
    class ScreenHandler
    {
        public ScreenHandler(string _title, int _windowWidth, int _windowHeight){

            Image icon = Raylib.LoadImage("EngineAssets/icon.png");

            Raylib.InitWindow(_windowWidth, _windowHeight, _title);
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
