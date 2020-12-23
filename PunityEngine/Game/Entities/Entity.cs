using System;
using Raylib_cs;
using System.Numerics;

namespace PunityEngine.Game.Entities
{
    public class Entity
    {
        public Vector2 position {get; set;}
        public Vector2 size {get; set;}
        public String name {get; set;}
        public int health {get; set;}

        public float scaleFactor {get; set;}

        public void Draw(){
            //All entities will have a draw function, Default is to simply draw a pink square.
            Raylib.DrawRectangle((int)position.X,(int)position.Y, (int)(size.X + 32 * scaleFactor), (int)(size.Y + 32 * scaleFactor), Color.PINK);          
        }

        public void Update(){
            //All entities will have an update function, up to the induvidual entity to imploment it.
        }

        //This method will get a multiplication factor on how to scale the size of the entity based on the screens height.
        public void ScaleToScreen(){
            //The original scale is set to 720p so the screen height / 720
            scaleFactor = (Raylib.GetScreenHeight() / 720f);
        }
    }
}
