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
    static class GameHandler
    {
        public enum Stages{
            MainMenu,
            CoopMenu,
            Settings,
            NewWorld,
            Game,

        }

        #region Stages
        static public MainMenu MainMenu = new MainMenu();
        static public CoopMenu coopMenu  = new CoopMenu();
        static public MainGame Game = new MainGame();
        static public Stages CurrentStage = Stages.MainMenu;
        #endregion

        static public void Draw(){
            // Will call the draw and function for each Stage, depening on wich is the
            // current one.
            switch (CurrentStage)
            {
                case Stages.MainMenu:
                    MainMenu.Draw();  
                break;

                case Stages.CoopMenu:
                    coopMenu.Draw();
                break;
                
                case Stages.Game:
                    Game.Draw();
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
        static public void Update(){

            switch (CurrentStage)
            {
                case Stages.MainMenu:
                    MainMenu.Update();  
                break;
                
                case Stages.CoopMenu:
                    coopMenu.Update();
                break;

                case Stages.Game:
                    Game.Update();
                break;

                case Stages.Settings:
                break;

                case Stages.NewWorld:
                break;

                default:
                break;
            }

            StageSwitcher();

            // This will act as the pause menu
            if (Raylib.IsKeyPressed(key: KeyboardKey.KEY_ESCAPE) && CurrentStage == Stages.Game)
            {
                CurrentStage = Stages.MainMenu;
            }
        }


        static public void StageSwitcher(){
            // This switch will check if a button that changes the Stage is pressed.
            switch (MainMenu.buttonPressed)
            {
                case MainMenu.buttonAlternatives.NewGame:
                    CurrentStage = Stages.Game;

                    // This will reset the button, preventing a stage switch each frame.
                    MainMenu.buttonPressed = MainMenu.buttonAlternatives.Empty;
                break;
                case MainMenu.buttonAlternatives.Coop:
                    CurrentStage = Stages.CoopMenu;

                    // This will reset the button, preventing a stage switch each frame.
                    MainMenu.buttonPressed = MainMenu.buttonAlternatives.Empty;
                break;
            }
        }
    }
}