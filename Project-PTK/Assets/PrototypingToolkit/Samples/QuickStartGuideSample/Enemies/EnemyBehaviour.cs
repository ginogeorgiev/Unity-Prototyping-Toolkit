using PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement;
using UnityEngine;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.Enemies
{
	public class EnemyBehaviour : MonoBehaviour
	{
		[Header("Debug")]
		[SerializeField] private GameData gameData;
		
		[Header("Debug")]
		[SerializeField] private Vector3 initialPlayerPosition;
		[SerializeField] private Vector3 moveDirection;
        
		private void OnEnable()
		{
			initialPlayerPosition = gameData.PlayerTransform.transform.position;
			
			LookAtPlayer();
			
			moveDirection = (initialPlayerPosition - transform.position).normalized;
		}
		
		private void Update()
		{
			HandleMovement();
		}
		
		private void LookAtPlayer()
		{
			Vector3 lookVector = initialPlayerPosition - transform.position;
			lookVector.y = transform.position.y;
			Quaternion rot = Quaternion.LookRotation(lookVector);
			transform.rotation = rot;
		}

		private void HandleMovement()
		{
			transform.position += moveDirection * (gameData.EnemyMovementSpeed.Get() * Time.deltaTime);
		}
	}
}
