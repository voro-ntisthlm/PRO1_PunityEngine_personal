using System;
using Raylib_cs;
using System.Numerics;

namespace PunityEngine.EngineAssets.UI
{
    public class Button
    {
        public Vector2 position = new Vector2(0,0);
        public Vector2 size = new Vector2(0,0);

        public Rectangle btnBounds = new Rectangle();

        Texture2D texture;
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

            btnBounds = new Rectangle(position.X, position.Y, size.X, size.Y);
        }

        public Button(Vector2 _pos, Texture2D _texture, Color _textColor, string _text)
        {
            position = _pos;
            size = new Vector2((float)_texture.width, (float)_texture.height);
            textColor = _textColor;
            text = _text;

            btnBounds = new Rectangle(position.X, position.Y, size.X, size.Y);
        }

        public Button(Vector2 _pos, Texture2D _texture)
        {
            position = _pos;
            size = new Vector2((float)_texture.width, (float)_texture.height);

            btnBounds = new Rectangle(position.X, position.Y, size.X, size.Y);
        }
        #endregion

        public void Draw(){
            if (IsHovered())
            {
                Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, Color.GRAY);
            }else{
                Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, backgroundColor);
            }

            //Draws the text in the center of the box, no matter what. using the formula:
            /*
                w2 = //whatever you want the width to be
                h2 = //whatever you want the height to be
                x2 = x1 + ((w1 - w2) / 2);
                y2 = y1 + ((h1 - h2) / 2);
            */
            Raylib.DrawText(
                text, 
                (int)position.X + ((int)size.X - Raylib.MeasureText(text, 30))/2, 
                (int)position.Y + ((int)size.Y - 30)/2 , 
                30, 
                textColor
            );

        }

        public bool IsHovered(){
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), btnBounds))
            {
                return true;
            }
            return false;
        }

        public bool IsClicked(){
            if (IsHovered() && Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON))
            {
                Console.WriteLine("Clicked");
                return true;
            }
            return false;
        }

    }
}
