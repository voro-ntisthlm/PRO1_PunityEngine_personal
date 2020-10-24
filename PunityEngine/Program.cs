using System;
using Raylib_cs;

namespace PunityEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            ScreenHandler screenHandler = new ScreenHandler("PunityEngine", 1280, 720);
    
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                Raylib.DrawCircle(100,20,20, Color.BLUE);            
                Raylib.EndDrawing();
            }
           
        }
    }
}
