using PrototypingToolkit.Core;
using UnityEngine;

namespace PrototypingToolkit.Samples.Logic
{
    public class DemoEndState : BaseState
    {
        private readonly GameObject result;
        
        public DemoEndState(GameObject result)
        {
            this.result = result;
        }
        
        protected override void OnEnter()
        {
            result.SetActive(true);
        }
        
        internal override void Execute()
        {
                 
        }
        
        protected override void OnExit()
        {
            result.SetActive(false);
        }
        
        public override bool HasNextState(BaseState nextState)
        {
            return nextState.GetType() == typeof(DemoPlayState);
        }
    }
}
