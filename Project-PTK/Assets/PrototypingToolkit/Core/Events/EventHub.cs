using System.Collections.Generic;
using System.Linq;
using MyBox;
using UnityEditor;
using UnityEngine;

namespace PrototypingToolkit.Core
{
	[System.Serializable]
	public class EventHubChannel
	{
		[SerializeField] private FeatureDomain featureDomain;
		
		[SerializeField] private List<EventBase> events;

		public FeatureDomain FeatureDomain
		{
			get => featureDomain;
			set => featureDomain = value;
		}

		public List<EventBase> Events
		{
			get => events;
			set => events = value;
		}
	}
	
#if UNITY_EDITOR
	[CreateAssetMenu(
		menuName = PTK_MenuNames.MN_EVENTHUB,
		fileName = PTK_MenuNames.FN_EVENTHUB,
		order = PTK_MenuNames.O_EVENTS)]
	public class EventHub : ScriptableObject
	{
		[SerializeField] private List<EventHubChannel> eventChannels;

		private void OnValidate()
		{
			SetLoggingSettings();
		}

		private void SetLoggingSettings()
		{
			if (eventChannels.Count == 0) return;
			
			foreach (EventHubChannel eventChannel in eventChannels)
			{
				if (!eventChannel.FeatureDomain) return;
				if (eventChannel.Events.Count == 0) return;
				
				foreach (EventBase @event in eventChannel.Events)
				{
					if (!@event) continue;

					@event.logEvent = eventChannel.FeatureDomain.LogEvent;
					@event.logColor = eventChannel.FeatureDomain.LogColor;
				}
			}
		}

		[BetterTooltip("Drop the Parent Path of all your Events here, then press Parse")]
		[SerializeField] private Object path;
		[ButtonMethod]
		private void ParseAllEventsInPath()
		{
			ParseScriptableObjects();
			SetLoggingSettings();
		}
		
		private void ParseScriptableObjects()
		{
			string folderPath = AssetDatabase.GetAssetPath(path);
			string[] guids = AssetDatabase.FindAssets("t:EventBase", new[] { folderPath });
			
			eventChannels.Clear();

			foreach (string guid in guids)
			{
				string assetPath = AssetDatabase.GUIDToAssetPath(guid);
				EventBase eventBase = AssetDatabase.LoadAssetAtPath<EventBase>(assetPath);

				if (eventBase == null) continue;

				bool wasAdded = false;
				foreach (EventHubChannel eventChannel in eventChannels
					         .Where(eventChannel => eventChannel.FeatureDomain == eventBase.FeatureDomain))
				{
					eventChannel.Events.Add(eventBase);
					wasAdded = true;
				}

				if (wasAdded) continue;
				
				CreateNewHubEntry(eventBase);
			}
		}

		private void CreateNewHubEntry(EventBase eventBase)
		{
			EventHubChannel x = new() { FeatureDomain = eventBase.FeatureDomain };
			eventChannels.Add(x);
			x.Events = new List<EventBase> { eventBase };
		}
	}
#endif
}
