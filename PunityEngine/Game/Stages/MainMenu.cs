using System;
using System.Numerics;
using Raylib_cs;
using PunityEngine.EngineAssets.UI;
using PunityEngine;

namespace PunityEngine.Game.Stages
{
    public class MainMenu : IStage
    {    
        #region UI elements
        static int topOffset = 20;
        Button newGame   = new Button(new Vector2(100, Raylib.GetScreenHeight()/10 +  70 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, "New Game");
        Button saves     = new Button(new Vector2(100, Raylib.GetScreenHeight()/10 + 120 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, "Saves");
        Button coop      = new Button(new Vector2(100, Raylib.GetScreenHeight()/10 + 170 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, "CO-OP");
        Button lvleditor = new Button(new Vector2(100, Raylib.GetScreenHeight()/10 + 220 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, "Level editor");
        Button settings  = new Button(new Vector2(100, Raylib.GetScreenHeight()/10 + 270 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, "Settings");
        Button exit      = new Button(new Vector2(100, Raylib.GetScreenHeight()/10 + 320 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, "Exit");        
        
        //Button spacing calc: 1/10 + [previus] + 10(diff) + 40 + topOffset
        #endregion

        public enum buttonAlternatives{
            empty,
            newGame,
            saves,
            coop,
            lvleditor,
            settings
        }

        public buttonAlternatives buttonPressed = buttonAlternatives.empty;

        //The main loop, every drawn element is called here.
        public void Draw(){
            DrawUI();
        }
        #region Draw Components
        public void DrawUI(){
            Raylib.DrawText("Some Platformer", 100, Raylib.GetScreenHeight()/10, 60, Color.WHITE);
            newGame.Draw();
            saves.Draw();
            coop.Draw();
            lvleditor.Draw();
            settings.Draw();
            exit.Draw();
        }

        void DrawBackground(){

        }
        void DrawGround(){
            
        }
        void DrawForground(){

        }
        #endregion

        //The update function is the logical loop, here all logic goes.
        public void Update(){
            if (newGame.IsClicked())
            {
                buttonPressed = buttonAlternatives.newGame;
            }
            else if (saves.IsClicked())
            {
                
            }
            else if (coop.IsClicked())
            {
                
            }
            else if (lvleditor.IsClicked())
            {
                
            }
            else if (settings.IsClicked())
            {
                
            }
            else if (exit.IsClicked())
            {
                Raylib.CloseWindow();
                Environment.Exit(1);
            }
        }
    }

}
