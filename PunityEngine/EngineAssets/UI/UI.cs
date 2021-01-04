using System;
using Raylib_cs;

namespace PunityEngine.EngineAssets.UI
{
    public class UI
    {
        // Every single UI element/component inherits this component.
        // Allowing them to scale with the screen height.
        public float ScaleFactor {get; set;}

        public void ScaleToScreen(){
            //The original scale is set to 720p so the screen height / 720
            ScaleFactor = Raylib.GetScreenHeight() / 720f;
        }
    }
}
