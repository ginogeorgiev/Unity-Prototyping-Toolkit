using System;

namespace PrototypingToolkit.Core
{
    public interface IDataEvent<T>
    {
        public void Raise(T data);
        public void Register(Action<T> listener);
        public void Unregister(Action<T> listener);
        public void RegisterAllowDuplicate(Action<T> listener);
    }
}
