using PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement;
using UnityEngine;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.Enemies
{
	public class EnemyContainerController : MonoBehaviour
	{
		[Header("Debug")]
		[SerializeField] private GameData gameData;
		
		private void Awake()
		{
			gameData.EnemyContainer = transform;
		}

		public void Clear()
		{
			foreach (Transform element in transform)
			{
				Destroy(element.gameObject);
			}
		}
	}
}
