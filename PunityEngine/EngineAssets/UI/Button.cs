using System;
using Raylib_cs;
using System.Numerics;

namespace PunityEngine.EngineAssets.UI
{
    public class Button
    {
        public Vector2 position = new Vector2(0,0);
        public Vector2 size = new Vector2(0,0);
        Color backgroundColor;
        Color textColor; 
        string text;
        
        #region Different types of buttons. Can pick wheter or not to use a solid color, use a textured background or only a texture.
        public Button(Vector2 _pos, Vector2 _size, Color _backgroundColor,Color _textColor, string _text)
        {
            position = _pos;
            size = _size;
            backgroundColor = _backgroundColor;
            textColor = _textColor;
            text = _text;
        }

        public Button(Vector2 _pos, Texture2D _texture, Color _textColor, string _text)
        {
            position = _pos;
            size = new Vector2((float)_texture.width, (float)_texture.height);
            textColor = _textColor;
            text = _text;
        }

        public Button(Vector2 _pos, Texture2D _texture)
        {
            position = _pos;
            size = new Vector2((float)_texture.width, (float)_texture.height);
        }
        #endregion

        public void Draw(){
            Raylib.BeginDrawing();
            
            
            Raylib.EndDrawing();
        }

    }
}
