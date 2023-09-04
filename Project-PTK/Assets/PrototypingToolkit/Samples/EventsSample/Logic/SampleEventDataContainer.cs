using PrototypingToolkit.Core;
using PrototypingToolkit.Core.PrimitiveTypes;
using UnityEngine;

namespace PrototypingToolkit.Samples.Logic
{
	public class SampleEventDataContainer : ScriptableObject
	{
		[Header("Data")]
		[SerializeField] private EmptyEvent on;
		[SerializeField] private EmptyEvent off;
		
		[SerializeField] private SampleDataEvent goOn;
		[SerializeField] private SampleDataEvent goOff;
		
		[SerializeField] private IntVariable onEventCounter;

		public EmptyEvent On => on;
		public EmptyEvent Off => off;
		public SampleDataEvent GOOn => goOn;
		public SampleDataEvent GOOff => goOff;

		public IntVariable OnEventCounter => onEventCounter;
	}
}
