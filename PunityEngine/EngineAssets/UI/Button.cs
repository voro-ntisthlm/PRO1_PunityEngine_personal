using System;
using Raylib_cs;
using System.Numerics;

namespace PunityEngine.EngineAssets.UI
{
    public class Button
    {
        #region Variables
        public Vector2 position = new Vector2(0,0);
        public Vector2 size = new Vector2(0,0);

        public Rectangle btnBounds = new Rectangle();

        Texture2D texture;
        Color backgroundColor;
        Color textColor;
        string text;
        #endregion

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
            texture = _texture;

            btnBounds = new Rectangle(position.X, position.Y, size.X, size.Y);
        }

        public Button(Vector2 _pos, Texture2D _texture)
        {
            position = _pos;
            size = new Vector2((float)_texture.width, (float)_texture.height);
            texture = _texture;

            btnBounds = new Rectangle(position.X, position.Y, size.X, size.Y);
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
                //if the user has defined a texuture it will not use this.
                //Depending on the IsHovered, it will change the backgound.
                if (IsHovered()){
                    Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, Color.GRAY);
                }else{
                    Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, backgroundColor);
                }
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
                (int)position.Y + ((int)size.Y - 30)/2, 
                30, 
                textColor
            );

        }

        #region Logic
        //This will check if the mouse is within the bounds of the button.
        public bool IsHovered(){
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), btnBounds))
            {
                return true;
            }
            return false;
        }

        //Using the IsHovered function, it will check the return value of it and also if the left mouse button is pressed.
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
