using System.Collections.Generic;
using UnityEngine;

namespace PrototypingToolkit.Core
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        [SerializeField] private List<T> items = new List<T>();
        
        [Header("Optional Event")]
        [SerializeField] private EmptyEvent onRuntimeSetChanged;

        public EmptyEvent OnRuntimeSetChanged
        {
            get => onRuntimeSetChanged;
            set => onRuntimeSetChanged = value;
        }

        public List<T> GetItems()
        {
            return items;
        }

        public void Add(T item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
                RaiseOnChangedEvent();
            }
        }

        public void Remove(T item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                RaiseOnChangedEvent();
            }
        }

        public void Restore()
        {
            items.Clear();
        }
        
        private void RaiseOnChangedEvent()
        {
            if (!onRuntimeSetChanged) return;
            onRuntimeSetChanged.Raise();
        }
    }
}
