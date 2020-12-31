using System;
using Raylib_cs;
using System.Numerics;

namespace PunityEngine.Game.Entities
{
    public class Entity
    {
        public Vector2 Position = new Vector2();
        public virtual Vector2 Size {get; set;}
        public virtual String Name {get; set;}
        public virtual int Health {get; set;}

        public float ScaleFactor {get; set;}


        public Texture2D texture;


        public virtual void Draw(){
            //All entities will have a draw function, Default is to simply draw a pink square.
            Raylib.DrawRectangle((int)Position.X,(int)Position.Y, (int)(Size.X + 32 * ScaleFactor), (int)(Size.Y + 32 * ScaleFactor), Color.PINK);          
        }

        public virtual void Update(){
            //All entities will have an update function, up to the induvidual entity to imploment it.
        }

        //This method will get a multiplication factor on how to scale the Size of the entity based on the screens height.
        public void ScaleToScreen(){
            //The original scale is set to 720p so the screen height / 720
            ScaleFactor = (Raylib.GetScreenHeight() / 720f);
        }
    }
}
