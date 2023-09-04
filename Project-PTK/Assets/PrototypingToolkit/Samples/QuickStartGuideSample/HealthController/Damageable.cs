using PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement;
using UnityEngine;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.HealthController
{
    public class Damageable : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private GameData gameData;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) return;
            
            gameData.DealDamageToPlayer.Raise();
        }
    }
}
