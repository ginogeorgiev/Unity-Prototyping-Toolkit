using System;
using System.Collections.Generic;
using MyBox;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PrototypingToolkit.Core
{
	[CreateAssetMenu(
		menuName = PTK_MenuNames.MN_EE,
		fileName = PTK_MenuNames.FN_EE,
		order = PTK_MenuNames.O_EVENTS)]
	public class EmptyEvent : EventBase, IEmptyEvent
	{
		[Header("Debug")]
		[SerializeField] private List<EmptyEventListener> inspectableListeners = new ();
		[SerializeField] private List<Object> componentActionListeners = new ();
		
		private event Action actionListeners;

		// ReSharper disable Unity.PerformanceAnalysis
		[ButtonMethod]
		public void Raise()
		{
			if (!Application.isPlaying) return;
			
			if (CheckForListeners()) return;

			RaiseForListeners();

			if (logEvent) Debug.Log($"{name} was raised.".Colored(logColor).Bold());
		}

		private bool CheckForListeners()
		{
			if (actionListeners != null || inspectableListeners.Count != 0) return false;
			
			Debug.LogWarning($"No active Listeners on EmptyEvent Raise: {name}".Colored(logColor));
			
			return true;
		}

		private void RaiseForListeners()
		{
			actionListeners?.Invoke();

			if (inspectableListeners.Count != 0)
			{
				for (int i = inspectableListeners.Count - 1; i >= 0; i--)
				{
					inspectableListeners[i].OnEventRaised();
				}
			}
		}

		public void Register(Action listener)
		{
			if (listener == null) return;
            
			actionListeners -= listener;
			actionListeners += listener;

			Object toAdd = listener.Target as Object;
			componentActionListeners.Add(toAdd);
		}

		public void Unregister(Action listener)
		{
			if (listener == null) return;
            
			actionListeners -= listener;
			
			Object toRemove = listener.Target as Object;
			componentActionListeners.Remove(toRemove);
		}
		
		public void RegisterAllowDuplicate(Action listener)
		{
			if (listener == null) return;
            
			actionListeners += listener;
		}
		
		public void Register(EmptyEventListener listener)
		{
			if (!inspectableListeners.Contains(listener))
			{
				inspectableListeners.Add(listener);
			}
		}

		public void Unregister(EmptyEventListener listener)
		{
			if (inspectableListeners.Contains(listener))
			{
				inspectableListeners.Remove(listener);
			}
		}

		public void RegisterAllowDuplicate(EmptyEventListener listener)
		{
			inspectableListeners.Add(listener);
		}
		
		public void OnDisable() { RemoveListeners(); }

		public void RemoveListeners()
		{
			inspectableListeners.Clear();
			componentActionListeners.Clear();
		}
	}
}
