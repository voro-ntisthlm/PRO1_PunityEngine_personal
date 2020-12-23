using System;

namespace PunityEngine.Game.Entities
{
    public class Player : Entity
    {
        public Player(){
            ScaleToScreen();
            Console.WriteLine(scaleFactor);
        }

    }
}
