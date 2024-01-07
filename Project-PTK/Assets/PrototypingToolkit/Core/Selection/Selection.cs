using UnityEngine;

namespace PrototypingToolkit.Core
{
    public abstract class Selection<T> : ScriptableObject
    {
        [SerializeField] private T selection;
        
        [Header("Optional Event")]
        [SerializeField] private EmptyEvent onSelectionChanged;

        public EmptyEvent OnSelectionChanged
        {
            get => onSelectionChanged;
            set => onSelectionChanged = value;
        }
        
        public void Restore()
        {
            selection = default;
            RaiseOnChangedEvent();
        }
        
        public T Get()
        {
            return selection;
        }

        public void Set(T value)
        {
            if (value == null)
            {
                selection = default(T);
                RaiseOnChangedEvent();
                return;
            }
            
            if (value.Equals(selection)) return;
            
            selection = value;
            RaiseOnChangedEvent();
        }
        
        private void RaiseOnChangedEvent()
        {
            if (!onSelectionChanged) return;
            onSelectionChanged.Raise();
        }
    }
}
