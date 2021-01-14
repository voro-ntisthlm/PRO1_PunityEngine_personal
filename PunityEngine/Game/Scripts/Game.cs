/////////////////////////////////////////////////////////////
//                   FILE INFO                             //
//  This is the entry point for the game, simmilar to      //
//  Program.cs in any other cs project.                    //
/////////////////////////////////////////////////////////////

using System;
using Raylib_cs;
using PunityEngine.Game.Stages;
using PunityEngine.Engine.Stage;

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

        static public void Run(){
            // Will call the draw and function for each Stage, depening on wich is the
            // current one.
            switch (CurrentStage)
            {
                case Stages.MainMenu:
                    MainMenu.Draw();
                    MainMenu.Update();
                break;

                case Stages.CoopMenu:
                    coopMenu.Draw();
                    coopMenu.Update();
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

            // This will act as the pause menu
            if (Raylib.IsKeyPressed(key: KeyboardKey.KEY_ESCAPE) && CurrentStage != Stages.MainMenu)
            {
                CurrentStage = Stages.MainMenu;
            }
        }
    }
}