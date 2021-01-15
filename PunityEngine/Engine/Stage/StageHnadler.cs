using System;
using System.Collections.Generic;
using Raylib_cs;

namespace PunityEngine.Engine.Stage
{
    public static class StageHandler
    {
        // This timer will be used to run the update function at the tick speed.
        static float tickTimerMaxValue = 0.05f;
        static float tickTimer = tickTimerMaxValue;


        // Creates a list of all loaded stages.
        public static List<IStage> stages = new List<IStage>();
        
        // This will be used when changing stages.
        public static Int16 currentStageID = 0;
        
        public static void Run()
        {
            // Run the necessary functions from the current stage (TM)
            stages[currentStageID].Draw();
            stages[currentStageID].Update();

            // NOTE: Mainly taken from the C# refs on classroom.
            // Makes the TickUpdate method run only once every 0.05 seconds (20 times a second)
            // Remove the frame time from the timer
            tickTimer -= Raylib.GetFrameTime();
            if(tickTimer <= 0){
                stages[currentStageID].TickUpdate();
                tickTimer = tickTimerMaxValue;
            }
        }

        // Current stage switchers
        // Will return a bool as a check, so that code can make sure that
        // the stage switch was successfull.
        public static bool SetCurrentStage(string stageName)
        {
            try
            {
                // Loop through the list of stages and get the id of that,
                // then if the stageName of the stage matches the stageName
                // parsed, assign that i value as the currentStageID.
                for (Int16 i = 0; i < stages.Count; i++)
                {
                    if (stages[i].stageName == stageName)
                    {
                        currentStageID = i;
                    }
                }
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        // If you are sure of the id, then simply use that instead of the name.
        // This simply assigns the currentStageID to the desired stageID,
        // same result as doing "StageHandler.currentStageID = ..."
        public static bool SetCurrentStage(Int16 stageID)
        {
            currentStageID = stageID;
            return true;

        }

        public static int GetCurrentStageIDbyName(string stageName){
            // Repeat some code from the SetCurrentStage().
            for (int i = 0; i < stages.Count; i++)
            {
                if (stages[i].stageName == stageName)
                {
                    return i;
                }
            }

            // Will default to 0 if it cant find anything.
            return 0;
        }

    }
}
