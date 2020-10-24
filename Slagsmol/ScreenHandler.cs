using System;
using Raylib_cs;

namespace Slagsmol
{
    class ScreenHandler
    {
        public ScreenHandler(string _title, int _windowWidth, int _windowHeight){
            Raylib.InitWindow(_windowWidth, _windowHeight, _title);
        }
    }
}
