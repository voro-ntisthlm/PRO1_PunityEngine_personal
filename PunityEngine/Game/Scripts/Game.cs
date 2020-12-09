using System;
using Raylib_cs;

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
        #endregion


        public GameHandler(){
        }

        //This function is run every frame.
        public void Update(){

            //This will check what "stage" you are in, so it can properly handle the stage.
            switch (currentStage)
            {
                case stage.MainMenu:
                    mainMenu.Draw();
                break;
                case stage.Settings:
                break;
                case stage.NewWorld:
                break;
                case stage.Game:
                break;
                default:
                break;
            }
        
        }
    }
}