using System;

namespace PrototypingToolkit.Core
{
    public interface IEmptyEvent
    {
        public void Raise();
        public void Register(Action listener);
        public void Unregister(Action listener);
        public void RegisterAllowDuplicate(Action listener);
        
        public void Register(EmptyEventListener listener);
        public void Unregister(EmptyEventListener listener);
        public void RegisterAllowDuplicate(EmptyEventListener listener);
        public void RemoveListeners();
    }
}
