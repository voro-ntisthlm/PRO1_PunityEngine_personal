using System;
using Raylib_cs;

using PunityEngine;
using PunityEngine.Game.Entities;

namespace PunityEngine.Game.Stages
{
    public class MainGame
    {
        Player player = new Player();       

        public void Draw(){
            player.Draw();
        }

        public void Update(){
            player.Update();
        }
    }
}
