using System;
using System.Collections.Generic;
using MyBox;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PrototypingToolkit.Core
{
	public class DataEvent<T> : EventBase, IDataEvent<T> where T : class
	{
		[Header("Debug")]
		[SerializeField] private List<Object> componentActionListeners = new ();
		
		private event Action<T> actionListeners;

		public void Raise(T data)
		{
			if (!Application.isPlaying) return;
			
			if (CheckForListeners()) return;

			RaiseForListeners(data);

			if (logEvent) Debug.Log($"{name} was raised.".Colored(logColor).Bold());
		}

		private bool CheckForListeners()
		{
			if (actionListeners != null ) return false;
			
			Debug.LogWarning($"No active Listeners on EmptyEvent Raise: {name}");
			return true;
		}

		private void RaiseForListeners(T data)
		{
			actionListeners?.Invoke(data);
		}

		public void Register(Action<T> listener)
		{
			if (listener == null) return;
            
			actionListeners -= listener;
			actionListeners += listener;
			
			Object toAdd = listener.Target as Object;
			componentActionListeners.Add(toAdd);
		}

		public void Unregister(Action<T> listener)
		{
			if (listener == null) return;
            
			actionListeners -= listener;
			
			Object toRemove = listener.Target as Object;
			componentActionListeners.Remove(toRemove);
		}
		
		public void RegisterAllowDuplicate(Action<T> listener)
		{
			if (listener == null) return;
            
			actionListeners += listener;
		}
		
		public void OnDisable() { RemoveListeners(); }

		public void RemoveListeners()
		{
			componentActionListeners.Clear();
		}
	}
}
