using System.Collections.Generic;
using UnityEngine;

namespace PrototypingToolkit.Core
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        [SerializeField] private List<T> items = new List<T>();

        public List<T> GetItems()
        {
            return items;
        }

        public void Add(T item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }
        }

        public void Remove(T item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
        }

        public void Restore()
        {
            items.Clear();
        }
    }
}
