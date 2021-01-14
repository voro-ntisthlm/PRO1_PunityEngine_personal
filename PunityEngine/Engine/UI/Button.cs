using System;
using Raylib_cs;
using System.Numerics;

namespace PunityEngine.Engine.UI
{
    public class Button : UI
    {
        #region Variables
        public int ID = 0;
        public Vector2 position = new Vector2(0,0);
        public Vector2 size = new Vector2(0,0);
        public Rectangle btnBounds = new Rectangle();

        Texture2D texture;
        Color backgroundColor;
        Color textColor;
        float fontSize;
        string text;

        #endregion

        #region Different types of buttons. Can pick wheter or not to use a solid color, use a textured background or only a texture.

        // This constructor defines a button with a solid color, and plain text.
        public Button(int _ID, Vector2 _pos, Vector2 _Size, Color _backgroundColor,Color _textColor, float _fontSize, string _text)
        {
            ID              = _ID; 
            position        = _pos;
            size            = _Size;
            backgroundColor = _backgroundColor;
            textColor       = _textColor;
            text            = _text;
            fontSize        = _fontSize;
            
            ScaleToScreen();

            // Multiply the value by the scalFactor
            position   *= ScaleFactor;
            size       *= ScaleFactor;

            fontSize   *= ScaleFactor;

            btnBounds = new Rectangle(position.X, position.Y, size.X, size.Y);
        }

        // This constructor defines a button with a texture as a background, and plain text.
        public Button(int _ID, Vector2 _pos, Texture2D _texture, Color _textColor, float _fontSize, string _text)
        {
            ID              = _ID; 
            position        = _pos;
            size            = new Vector2((float)_texture.width, (float)_texture.height);
            textColor       = _textColor;
            text            = _text;
            texture         = _texture;
            fontSize        = _fontSize;

            ScaleToScreen();
    
            // Multiply the value by the scalFactor
            position *= ScaleFactor;
            size     *= ScaleFactor;
            
            fontSize   *= ScaleFactor;

            btnBounds  = new Rectangle(position.X, position.Y, size.X, size.Y);
        }

        // This constructor defines a button with only a texture.
        public Button(int _ID, Vector2 _pos, Texture2D _texture)
        {
            ID              = _ID; 
            position        = _pos;
            size            = new Vector2((float)_texture.width, (float)_texture.height);
            texture         = _texture;

            ScaleToScreen();

            // Multiply the value by the scalFactor
            position *= ScaleFactor;
            size     *= ScaleFactor;

            btnBounds       = new Rectangle(position.X, position.Y, size.X, size.Y);
        }
        #endregion

        public void Draw(){
            
            
            if (texture.height != 0)
            {
                if (IsHovered()){
                    Raylib.DrawTextureRec(texture, new Rectangle(0, 0, size.X, size.Y) , position, Color.GRAY);
                }else{
                    Raylib.DrawTextureRec(texture, new Rectangle(0, 0, size.X, size.Y) , position, Color.WHITE);
                }
            }
            else{
                // if the user has defined a texuture it will not use this.
                // Depending on the IsHovered, it will change the backgound.
                if (IsHovered()){
                    Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, Color.GRAY);
                }else{
                    Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, backgroundColor);
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
                (int)position.X + ((int)size.X - Raylib.MeasureText(text, (int)fontSize))/2, 
                (int)position.Y + ((int)size.Y - (int)fontSize)/2, 
                (int)fontSize, 
                textColor
            );

        }

        #region Logic
        // This will check if the mouse is within the bounds of the button.
        public bool IsHovered(){
            return (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), btnBounds));
        }

        // Using the IsHovered function, it will check the return value of it and also if the left mouse button is pressed.
        public bool IsClicked(){
            return (IsHovered() && Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON));
        }
        #endregion
    }
}
