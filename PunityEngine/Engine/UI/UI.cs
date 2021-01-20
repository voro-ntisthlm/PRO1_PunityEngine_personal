using System;
using Raylib_cs;

namespace PunityEngine.Engine.UI
{
    public class UI
    {
        // Every single UI element/component inherits this component.
        // Allowing them to scale with the screen height.
        public float ScaleFactor {get; set;}
        public int ID {get; set;}

        public void ScaleToScreen(){
            // The original scale is set to 720p so the screen height / 720
            ScaleFactor = Raylib.GetScreenHeight() / 720f;
        }

        public virtual bool IsHovered(){return false;}
        public virtual bool IsClicked(){return false;}

    }

    public interface IUI
    {
        int ID {get; set;}
        
        void ScaleToScreen();
        void Draw();

        bool IsClicked();
        bool IsHovered();

    }
}
