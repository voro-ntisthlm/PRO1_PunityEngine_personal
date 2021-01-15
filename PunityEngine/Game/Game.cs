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
        static public void Init(){
            // Add all stages that should be loaded at start time.
            // NOTE: The first added will be the first loaded and drawed.
            StageHnadler.stages.Add(new MainMenu("MainMenu"));
            StageHnadler.stages.Add(new CoopMenu("Coop"    ));
        }

        static public void Run(){

            // This will act as the pause menu
            if (Raylib.IsKeyPressed(key: KeyboardKey.KEY_ESCAPE) && StageHnadler.currentStageID != 0)
            {
                StageHnadler.SetCurrentStage("MainMenu");
            }
        }
    }
}