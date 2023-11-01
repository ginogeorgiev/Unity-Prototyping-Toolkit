using System;
using UnityEngine;

namespace PrototypingToolkit.Core
{
    /// <summary>
    /// A Class can derive from StateMachine in order to be state driven and decides whether
    /// a State is changed or not based on Events or Inputs and communicates it to
    /// the StateMachine and if it does it provides a new State (Object derived from BaseState).
    /// Those Objects have to be created on its own based on the available states and must implement BaseState!
    /// </summary>
    
    public abstract class StateMachine : MonoBehaviour
    {
        [SerializeField] public CurrentStateData currentStateData;

        protected void Initialize(BaseState initialState)
        {
            currentStateData.SetState(initialState);
        }

        protected void Execute()
        {
            currentStateData.Get().Execute();
        }

        protected void TransitionTo(BaseState targetState)
        {
            if (!currentStateData.Get().HasNextState(targetState))
                throw new InvalidOperationException
                ($"Invalid state transition: " +
                 $"{currentStateData.Get().GetType().Name} to {targetState.GetType().Name}");

            currentStateData.Get().Exit();
            
            currentStateData.SetState(targetState);
        }
    }
}
