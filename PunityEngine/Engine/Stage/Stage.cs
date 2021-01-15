using System;

namespace PunityEngine.Engine.Stage
{
    public interface IStage
    {
        string stageName {get; set;}
        void Draw(){}
        void DrawBackground(){}   
        void DrawGame(){}
        void DrawUI(){}
        void Update(){}
        void TickUpdate(){}
        
    }

    public class Stage
    {
        public string stageName {get; set;}
     
        // These methods will be overriden by each stage
        public virtual void Draw(){
            DrawBackground();
            DrawGame();
            DrawUI();
        }
        public virtual void DrawBackground(){}   
        public virtual void DrawGame(){}
        public virtual void DrawUI(){}
        public virtual void Update(){}
        public virtual void TickUpdate(){}
        
    }
}