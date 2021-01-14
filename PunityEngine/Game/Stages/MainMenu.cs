using System;
using System.Numerics;
using Raylib_cs;
using PunityEngine.Engine.UI;
using PunityEngine;

namespace PunityEngine.Game.Stages
{
    public class MainMenu
    {    
        #region UI elements
        
        static int topOffset = 20;
        
        // Here I define all of the menu buttons.
        Button[] buttons = {
            // Button spacing calc: 1/10 + [previus] + 10(diff) + 40 + topOffset
            new Button(0, new Vector2(100, Raylib.GetScreenHeight()/10 +  70 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "New Game"    ),
            new Button(1, new Vector2(100, Raylib.GetScreenHeight()/10 + 120 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "Saves"       ),
            new Button(2, new Vector2(100, Raylib.GetScreenHeight()/10 + 170 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "CO-OP"       ),
            new Button(3, new Vector2(100, Raylib.GetScreenHeight()/10 + 220 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "Level editor"),
            new Button(4, new Vector2(100, Raylib.GetScreenHeight()/10 + 270 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "Settings"    ),
            new Button(5, new Vector2(100, Raylib.GetScreenHeight()/10 + 320 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "Exit"        )
        };

        Label[] labels = {
            new Label("Some Platformer", new Vector2(100, Raylib.GetScreenHeight()/10), 60, Color.WHITE)
        };  
        
        #endregion


        public enum buttonAlternatives{
            Empty,
            NewGame,
            Saves,
            Coop,
            LvlEditor,
            Settings
        }


        public buttonAlternatives buttonPressed = buttonAlternatives.Empty;


        // The main loop, every drawn element is called here.
        public void Draw(){
            DrawUI();
        }

        // Put all UI elements in here.
        public void DrawUI(){
            
            // Loop through all buttons, as its an array of buttons,
            // all of 'em has a draw function. 
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Draw();
            }

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Draw();
            }
        }


        // The update function is the logical loop, here all logic goes.
        public void Update(){
            // Loop through all of the buttons, and check what button is being pressed,
            // Act acordingly.
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].IsClicked())
                {
                    switch (buttons[i].ID)
                    {
                        case 0: // New Game
                            buttonPressed = buttonAlternatives.NewGame;
                        break;
                        case 2: // Coop
                            buttonPressed = buttonAlternatives.Coop;
                        break;
                        case 5: // Exit
                            Raylib.CloseWindow();
                            Environment.Exit(1);
                        break;
                    }   
                }    
            }
        }
    }

}
