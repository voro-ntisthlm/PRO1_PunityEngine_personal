using System;
using System.Numerics;
using Raylib_cs;
using PunityEngine.Engine.UI;
using PunityEngine;
using PunityEngine.Engine.Network;
using PunityEngine.Engine.Stage;

namespace PunityEngine.Game.Stages
{
    public class CoopMenu : Stage, IStage
    {
        public CoopMenu(string _stageName){
            stageName = _stageName;
        }

        #region UI elements
        
        static int topOffset = 20;
        
        // Here I define all of the menu buttons.
        Button[] buttons = {
            // Button spacing calc: 1/10 + [previous] + 10(diff) + 40 + topOffset
            new Button(0, new Vector2(100, Raylib.GetScreenHeight()/10 +  70 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "Join Game"),
            new Button(1, new Vector2(100, Raylib.GetScreenHeight()/10 + 120 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "Host"   ),
            new Button(2, new Vector2(100, Raylib.GetScreenHeight()/10 + 170 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "Back"   ),
        };

        Label[] labels = {
            new Label("Co-op", new Vector2(100, Raylib.GetScreenHeight()/10), 60, Color.WHITE)
        };  
        
        #endregion


        // Put all UI elements in here.
        public override void DrawUI(){
            
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
        public override void Update(){
            // Loop through all of the buttons, and check what button is being pressed,
            // Act accordingly.
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].IsClicked())
                {
                    switch (buttons[i].ID)
                    {
                        case 0: // Join
                            Console.WriteLine("Join code yay");
                        break;
                        case 1: // Host
                            Host.InitHost();
                        break;
                        case 2: // Back
                            StageHandler.SetCurrentStage("MainMenu");
                        break;
                    }   
                }    
            }
        }
    }

}
