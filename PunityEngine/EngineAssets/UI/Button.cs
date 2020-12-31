using System;
using Raylib_cs;
using System.Numerics;

namespace PunityEngine.EngineAssets.UI
{
    public class Button
    {
        #region Variables
        // Public variables are named with a Capital letter.
        public int ID = 0;
        public Vector2 Position = new Vector2(0,0);
        public Vector2 Size = new Vector2(0,0);
        public Rectangle BtnBounds = new Rectangle();

        Texture2D texture;
        Color backgroundColor;
        Color textColor;
        string text;

        #endregion

        #region Different types of buttons. Can pick wheter or not to use a solid color, use a textured background or only a texture.

        // This constructor defines a button with a solid color, and plain text.
        public Button(int _ID, Vector2 _pos, Vector2 _Size, Color _backgroundColor,Color _textColor, string _text)
        {
            ID              = _ID; 
            Position        = _pos;
            Size            = _Size;
            backgroundColor = _backgroundColor;
            textColor       = _textColor;
            text            = _text;

            BtnBounds = new Rectangle(Position.X, Position.Y, Size.X, Size.Y);
        }

        // This constructor defines a button with a texture as a background, and plain text.
        public Button(int _ID, Vector2 _pos, Texture2D _texture, Color _textColor, string _text)
        {
            ID              = _ID; 
            Position        = _pos;
            Size            = new Vector2((float)_texture.width, (float)_texture.height);
            textColor       = _textColor;
            text            = _text;
            texture         = _texture;

            BtnBounds   = new Rectangle(Position.X, Position.Y, Size.X, Size.Y);
        }

        // This constructor defines a button with only a texture.
        public Button(int _ID, Vector2 _pos, Texture2D _texture)
        {
            ID              = _ID; 
            Position        = _pos;
            Size            = new Vector2((float)_texture.width, (float)_texture.height);
            texture         = _texture;

            BtnBounds       = new Rectangle(Position.X, Position.Y, Size.X, Size.Y);
        }
        #endregion

        public void Draw(){
            
            
            if (texture.height != 0)
            {
                if (IsHovered()){
                    Raylib.DrawTextureRec(texture, new Rectangle(0, 0, Size.X, Size.Y) , Position, Color.GRAY);
                }else{
                    Raylib.DrawTextureRec(texture, new Rectangle(0, 0, Size.X, Size.Y) , Position, Color.WHITE);
                }
            }
            else{
                // if the user has defined a texuture it will not use this.
                // Depending on the IsHovered, it will change the backgound.
                if (IsHovered()){
                    Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y, Color.GRAY);
                }else{
                    Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y, backgroundColor);
                }
            }
            

            // Draws the text in the center of the box, no matter what. using the formula:
            /*
                w2 = // whatever you want the width to be
                h2 = // whatever you want the height to be
                x2 = x1 + ((w1 - w2) / 2);
                y2 = y1 + ((h1 - h2) / 2);
            */
            Raylib.DrawText(
                text, 
                (int)Position.X + ((int)Size.X - Raylib.MeasureText(text, 30))/2, 
                (int)Position.Y + ((int)Size.Y - 30)/2, 
                30, 
                textColor
            );

        }

        #region Logic
        // This will check if the mouse is within the bounds of the button.
        public bool IsHovered(){
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), BtnBounds))
            {
                return true;
            }
            return false;
        }

        // Using the IsHovered function, it will check the return value of it and also if the left mouse button is pressed.
        public bool IsClicked(){
            if (IsHovered() && Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
