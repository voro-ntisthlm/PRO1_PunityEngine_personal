using System;
using System.Numerics;
using Raylib_cs;
using PunityEngine.Engine.UI;
using PunityEngine;
using PunityEngine.Engine.Network;

namespace PunityEngine.Game.Stages
{
    public class CoopMenu
    {    
        #region UI elements
        
        static int topOffset = 20;
        
        // Here I define all of the menu buttons.
        Button[] buttons = {
            // Button spacing calc: 1/10 + [previus] + 10(diff) + 40 + topOffset
            new Button(0, new Vector2(100, Raylib.GetScreenHeight()/10 +  70 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "Join Game"),
            new Button(1, new Vector2(100, Raylib.GetScreenHeight()/10 + 120 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "Host"   ),
        };

        Label[] labels = {
            new Label("Co-op", new Vector2(100, Raylib.GetScreenHeight()/10), 60, Color.WHITE)
        };  
        
        #endregion


        public enum buttonAlternatives{
            Empty,
            Join,
            Host,
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
                        case 0: // Join
                            buttonPressed = buttonAlternatives.Join;
                        break;
                        case 1: // Host
                            Host.InitHost();
                        break;
                    }   
                }    
            }
        }
    }

}
