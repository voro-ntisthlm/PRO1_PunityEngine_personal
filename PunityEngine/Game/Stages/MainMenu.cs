using System;
using Raylib_cs;

namespace PunityEngine
{
    public class MainMenu
    {    
        public void Draw(){
            Raylib.DrawText("Some Platformer", 100, Raylib.GetScreenHeight()/10, 60, Color.WHITE);
        }
    }

}
