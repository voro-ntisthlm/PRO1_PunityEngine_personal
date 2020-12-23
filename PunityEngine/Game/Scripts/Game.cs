using System;
using Raylib_cs;
using PunityEngine.Game.Stages;

namespace PunityEngine
{
    class GameHandler
    {
        public enum stage{
            MainMenu,
            Settings,
            NewWorld,
            Game,

        }

        public stage currentStage = stage.MainMenu;
        
        #region Stages
        public MainMenu mainMenu = new MainMenu();
        public MainGame game = new MainGame();
        #endregion


        public GameHandler(){
        }

        //This function is run every frame.
        public void Update(){

            //This will check what "stage" you are in, so it can properly handle the stage.
            //Stage handler:
            switch (currentStage)
            {
                case stage.MainMenu:
                    mainMenu.Draw();
                    mainMenu.Update();

                    //This switch will check if a button that changes the stage is pressed.
                    switch (mainMenu.buttonPressed)
                    {
                        case MainMenu.buttonAlternatives.newGame:
                            currentStage = stage.Game;
                        break;
                    }
                break;

                case stage.Settings:
                break;
                case stage.NewWorld:
                break;
                case stage.Game:
                    game.Draw();
                    game.Update();
                break;
                default:
                break;
            }       
        }
    }
}