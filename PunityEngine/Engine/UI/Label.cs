using System;
using System.Numerics;
using Raylib_cs;

namespace PunityEngine.Engine.UI
{
    public class Label : UI, IUI
    {
        public string text {get; set;}
        public Vector2 position {get; set;}
        public float fontSize {get; set;}
        public Color colorTint {get; set;}

        public Label(string _text, Vector2 _position, int _fontSize, Color _colorTint){
            
            ScaleToScreen();

            text        = _text;
            position    = _position;
            fontSize    = _fontSize;
            colorTint   = _colorTint;

            // Assign the scale
            position *= ScaleFactor;
            fontSize *= ScaleFactor;
        }

        public void Draw(){
            Raylib.DrawText(text, (int)position.X, (int)position.Y, (int)fontSize, colorTint);
        }
    }
}
