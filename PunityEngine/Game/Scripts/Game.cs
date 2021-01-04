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
        public enum Stages{
            MainMenu,
            Settings,
            NewWorld,
            Game,

        }

        
        #region Stages
        public MainMenu MainMenu = new MainMenu();
        public MainGame Game = new MainGame();
        public Stages CurrentStage = Stages.MainMenu;
        #endregion

        public void Draw(){
            // Will call the draw and update function for each Stage, depening on wich is the
            // current one.
            switch (CurrentStage)
            {
                case Stages.MainMenu:
                    MainMenu.Draw();
                    MainMenu.Update();  
                break;
                
                case Stages.Game:
                    Game.Draw();
                    Game.Update();
                break;

                case Stages.Settings:
                break;

                case Stages.NewWorld:
                break;

                default:
                break;
            }
        }

        // Any code that should be run each frame shall go in here,
        // if that code needs to be run no matter what stage it is in.
        public void Update(){
            StageSwitcher();

            // This will act as the pause menu
            if (Raylib.IsKeyPressed(key: KeyboardKey.KEY_ESCAPE) && CurrentStage == Stages.Game)
            {
                CurrentStage = Stages.MainMenu;
            }
        }


        public void StageSwitcher(){
            // This switch will check if a button that changes the Stage is pressed.
            switch (MainMenu.buttonPressed)
            {
                case MainMenu.buttonAlternatives.NewGame:
                    CurrentStage = Stages.Game;
                    MainMenu.buttonPressed = MainMenu.buttonAlternatives.Empty; // This will reset the button, preventing a bug.
                break;
            }
        }
    }
}