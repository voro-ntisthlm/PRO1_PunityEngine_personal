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

        public stage CurrentStage = stage.MainMenu;
        
        #region Stages
        public MainMenu MainMenu = new MainMenu();
        public MainGame Game = new MainGame();
        #endregion


        public GameHandler(){
        }

        //This function is run every frame.
        public void Update(){

            //This will check what "stage" you are in, so it can properly handle the stage.
            //Stage handler:
            switch (CurrentStage)
            {
                case stage.MainMenu:
                    MainMenu.Draw();
                    MainMenu.Update();

                    //This switch will check if a button that changes the stage is pressed.
                    switch (MainMenu.buttonPressed)
                    {
                        case MainMenu.buttonAlternatives.NewGame:
                            CurrentStage = stage.Game;
                        break;
                    }
                break;

                case stage.Settings:
                break;
                case stage.NewWorld:
                break;
                case stage.Game:
                    Game.Draw();
                    Game.Update();
                break;
                default:
                break;
            }       
        }
    }
}