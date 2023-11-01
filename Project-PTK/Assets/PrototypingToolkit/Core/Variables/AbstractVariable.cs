using UnityEngine;

namespace PrototypingToolkit.Core
{
    public abstract class AbstractVariable<T> : ScriptableObject
    {
        [BetterTooltip("Start Value should only be set in the inspector, \n or when instantiating Variables")]
        [SerializeField] private T startValue;
        
        [BetterTooltip("Current Value is not needed to be set in the inspector, \n but can be changed at runtime for testing")]
        [SerializeField] protected T currentValue;

        [Header("Optional Event")]
        [SerializeField] protected EmptyEvent onCurrentChanged;
        
        public T Get() => currentValue;
        
        public T StartValue
        {
            get => startValue;
            set => startValue = value;
        }

        public EmptyEvent OnCurrentChanged
        {
            get => onCurrentChanged;
            set => onCurrentChanged = value;
        }

        public void Set(T value)
        {
            if (value.Equals(currentValue)) return;
            currentValue = value;
            
            RaiseOnCurrentChangedEvent();
        }

        public void Set(T value, bool raiseChangedEvent)
        {
            if (value.Equals(currentValue)) return;
            currentValue = value;
            
            if (raiseChangedEvent) RaiseOnCurrentChangedEvent();
        }

        private void OnValidate()
        {
            RaiseOnCurrentChangedEvent();
        }

        private void OnDisable()
        {
            Restore();
        }

        public void Restore()
        {
            Set(startValue);
        }
        
        protected void RaiseOnCurrentChangedEvent()
        {
            RaiseOnChangedEvent();
        }

        private void RaiseOnChangedEvent()
        {
            if (!onCurrentChanged) return;
            onCurrentChanged.Raise();
        }

        public void Copy(AbstractVariable<T> other) => currentValue = other.currentValue;

        public override string ToString()
        {
            return Get().ToString();
        }
    }
}
