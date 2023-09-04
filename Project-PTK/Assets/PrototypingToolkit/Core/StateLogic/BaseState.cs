
namespace PrototypingToolkit.Core
{
    public abstract class BaseState
    {
        protected StateData Data { get; }

        protected BaseState(StateData data)
        {
            Data = data;
        }

        protected BaseState() { }
        
        private void OnBeforeEnter()
        {
            if (!Data) return;
            if (Data.OnBeforeEnterEvent) Data.OnBeforeEnterEvent.Raise(this);
        }

        internal void Enter()
        {
            OnBeforeEnter();
            OnEnter();
            OnAfterEnter();
        }

        protected abstract void OnEnter();
        
        private void OnAfterEnter()
        {
            if (!Data) return;
            if (Data.OnAfterEnterEvent) Data.OnAfterEnterEvent.Raise(this);
            if (Data.IsExecuting) Data.IsExecuting.SetTrue();
        }

        internal virtual void Execute()
        {
            
        }
        
        private void OnBeforeExit()
        {
            if (!Data) return;
            if (Data.IsExecuting) Data.IsExecuting.SetFalse();
            if (Data.OnBeforeExitEvent) Data.OnBeforeExitEvent.Raise(this);
        }
        
        internal void Exit()
        {
            OnBeforeExit();
            OnExit();
            OnAfterExit();
        }

        protected abstract void OnExit();
        
        private void OnAfterExit()
        {
            if (!Data) return;
            if (Data.OnAfterExitEvent) Data.OnAfterExitEvent.Raise(this);
        }

        public abstract bool HasNextState(BaseState nextState);
    }
}
