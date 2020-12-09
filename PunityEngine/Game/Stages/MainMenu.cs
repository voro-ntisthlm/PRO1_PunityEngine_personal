using System;
using System.Numerics;
using Raylib_cs;
using PunityEngine.EngineAssets.UI;

namespace PunityEngine
{
    public class MainMenu
    {    
        #region UI elements
        Button newGame   = new Button(new Vector2(100, Raylib.GetScreenHeight()/10 + 70), new Vector2(250, 40), Color.WHITE, Color.BLACK, "New Game");
        Button saves     = new Button(new Vector2(100, Raylib.GetScreenHeight()/10 + 120), new Vector2(250, 40), Color.WHITE, Color.BLACK, "Saves");
        Button coop      = new Button(new Vector2(100, Raylib.GetScreenHeight()/10 + 170), new Vector2(250, 40), Color.WHITE, Color.BLACK, "CO-OP");
        Button lvleditor = new Button(new Vector2(100, Raylib.GetScreenHeight()/10 + 220), new Vector2(250, 40), Color.WHITE, Color.BLACK, "Level editor");
        Button settings  = new Button(new Vector2(100, Raylib.GetScreenHeight()/10 + 270), new Vector2(250, 40), Color.WHITE, Color.BLACK, "Settings");
        Button exit      = new Button(new Vector2(100, Raylib.GetScreenHeight()/10 + 320), new Vector2(250, 40), Color.WHITE, Color.BLACK, "Exit");        
        
        //Button spacing calc: 1/10 + [previus] + 10(diff) + 40
        #endregion


        //The main loop, every drawn element is called here.
        public void Draw(){
            Raylib.DrawText("Some Platformer", 100, Raylib.GetScreenHeight()/10, 60, Color.WHITE);
            newGame.Draw();
            saves.Draw();
            coop.Draw();
            lvleditor.Draw();
            settings.Draw();
            exit.Draw();
            
        }

        //The update function is the logical loop, here all logic goes.
        public void Update(){
            if (newGame.IsClicked())
            {
                Console.WriteLine("Update loop");
            }
        }
    }

}
