using System.Collections;
using PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.Enemies
{
	public class EnemySpawnerBehaviour : MonoBehaviour
	{
		[Header("Data")]
		[SerializeField] private GameData gameData;
		
		[Header("Internal Ref")]
		[SerializeField] private SphereCollider deSpawnRadius;
		
		[Header("External Ref")]
		[SerializeField] private EnemyBehaviour enemy;
		
		private void OnEnable()
		{
			StartCoroutine(SpawnEnemies());
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		private IEnumerator SpawnEnemies()
		{
			while (true)
			{
				while (!gameData.PlayerTransform)
				{
					yield return null;
				}
				Vector2 randomPosition = Random.insideUnitCircle.normalized * gameData.SpawnRadius.Get();
				Vector3 spawnPosition = new Vector3(
					randomPosition.x + gameData.PlayerTransform.position.x,
					0f,
					randomPosition.y + gameData.PlayerTransform.position.z);

				EnemyBehaviour newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity, gameData.EnemyContainer);

				yield return new WaitForSeconds(gameData.SpawnRate.Get());
			}
		}

		private void OnTriggerExit(Collider other)
		{
			Destroy(other.transform.parent.gameObject);
		}

		private void OnDrawGizmosSelected()
		{
			deSpawnRadius.radius = gameData.DeSpawnRadius.Get();
			
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, gameData.SpawnRadius.Get());

			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, gameData.DeSpawnRadius.Get());
		}
	}
}
