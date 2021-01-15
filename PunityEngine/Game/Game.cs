/////////////////////////////////////////////////////////////
//                   FILE INFO                             //
//  This is the entry point for the game, similar to       //
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
        static public void Init(){
            // Add all stages that should be loaded at start time.
            // NOTE: The first added will be the first loaded and drawn.
            StageHandler.stages.Add(new MainMenu("MainMenu"));
            StageHandler.stages.Add(new CoopMenu("Coop"    ));
            StageHandler.stages.Add(new MainGame("Game"    ));
        }

        static public void Run(){

            // This will act as the pause menu, when not in the main menu.
            if (Raylib.IsKeyPressed(key: KeyboardKey.KEY_ESCAPE) && StageHandler.currentStageID != 0)
            {
                StageHandler.SetCurrentStage("MainMenu");
            }
        }
    }
}