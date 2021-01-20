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
        /// <summary>
        /// Use the name of a stage to set it as the currentStageID.
        /// Returns true if successfull, false if not.
        ///</summary>
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

        /// <summary>
        /// If you are sure of the id, then simply use that instead of the name.
        /// This simply assigns the currentStageID to the desired ID,
        /// same result as doing "StageHandler.currentStageID = [int]"
        ///</summary>
        public static bool SetCurrentStage(Int16 stageID)
        {
            currentStageID = stageID;
            return true;

        }

        /// <summary>Returns the ID of the stage by using the parsed stageName paramater.</summary>
        public static int GetCurrentStageIDbyName(string stageName)
        {
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

        /// <summary>This will return true if the stage name parsed exists within the stage list, otherwise it will return false.</summary>
        public static bool StageExists(string stageName)
        {
            // Repeat some code from the SetCurrentStage().
            for (int i = 0; i < stages.Count; i++)
            {
                if (stages[i].stageName == stageName)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>This will check the stageName of a stage, and remove it from the list of stages.</summary>
        /// <param name="fallbackStageID">An optional fallback stage that can be set to change the stage when called.</param>
        public static bool UnloadStage(string stageName, Int16 fallbackStageID = default(int))
        {
            for (int i = 0; i < stages.Count; i++)
            {
                if (stages[i].stageName == stageName)
                {
                    try
                    {
                        stages.RemoveAt(i);
                        
                        // If the user has supplied a fallback stage, it will set
                        // that stage as the current stage.
                        if (fallbackStageID != default(int))
                            currentStageID = fallbackStageID;

                        return true;
                    }
                    catch (System.Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>Will remove the currently loaded stage from the list, also sets the current stage id so that it will not display a black screen.</summary>
        /// <param name="fallbackStageID">An optional stage id, default set to 0, ie the first thing in the stage list.</param>
        public static bool UnloadCurrentStage(Int16 fallbackStageID = default(int))
        {
            try
            {
                stages.RemoveAt(currentStageID);
                
                // If the user has supplied a fallback stage, it will set
                // that stage as the current stage.
                if (fallbackStageID != default(int))
                    currentStageID = fallbackStageID;
                else currentStageID = 0;
                
                return true;   
            }
            catch (System.Exception)
            {
                return false;
            }

        }

        /// <summary>Simply makes the syntax StageHandler.stages.add(new IStage); a bit easier by doing StageHandler.AddStage(). 
        /// Preforms a try where it adds the stage to the list.</summary>
        /// <param name="newStage">The stage that should be added.</param>
        public static bool AddStage(IStage newStage)
        {
            try
            {
                stages.Add(newStage);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>The LoadStage method works in the same way as AddStage, but it also sets it as the current stage.</summary>
        /// <param name="newStage">The stage that should be added.</param>
        public static bool LoadStage(IStage newStage)
        {
            try
            {
                stages.Add(newStage);
                SetCurrentStage(newStage.stageName);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
