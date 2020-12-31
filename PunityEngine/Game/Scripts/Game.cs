/////////////////////////////////////////////////////////////
//                   FILE INFO                             //
//  This is the entry point for the game, simmilar to      //
//  Program.cs in any other cs project.                    //
/////////////////////////////////////////////////////////////

using System;
using Raylib_cs;
using PunityEngine.Game.Stages;

namespace PunityEngine
{
    class GameHandler
    {
        public enum Stage{
            MainMenu,
            Settings,
            NewWorld,
            Game,

        }

        
        #region Stages
        public MainMenu MainMenu = new MainMenu();
        public MainGame Game = new MainGame();
        public Stage CurrentStage = Stage.MainMenu;
        #endregion

        public void Draw(){
            // Will call the draw and update function for each Stage, depening on wich is the
            // current one.
            switch (CurrentStage)
            {
                case Stage.MainMenu:
                    MainMenu.Draw();
                    MainMenu.Update();  
                break;
                
                case Stage.Game:
                    Game.Draw();
                    Game.Update();
                break;

                case Stage.Settings:
                break;

                case Stage.NewWorld:
                break;

                default:
                break;
            }
        }

        // Any code that should be run each frame shall go in here,
        // if that code needs to be run no matter what stage it is in.
        public void Update(){
            StageSwitcher();
        }


        public void StageSwitcher(){
            // This switch will check if a button that changes the Stage is pressed.
            switch (MainMenu.buttonPressed)
            {
                case MainMenu.buttonAlternatives.NewGame:
                CurrentStage = Stage.Game;
                break;
            }
        }
    }
}