using UnityEngine;

namespace PrototypingToolkit.Samples.Logic
{
	public class SampleEventCubeBehaviour : MonoBehaviour
	{
		[SerializeField] private bool log;

		private void OnEnable()
		{
			if (log) Debug.Log("Cube activated");
		}

		private void OnDisable()
		{
			if (log) Debug.Log("Cube deactivated");
		}

		public void Some()
		{
			Debug.Log("Some");
		}
	}
}
