using PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement;
using UnityEngine;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.HealthController
{
    public class HealthController : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private GameData gameData;

        private void OnEnable()
        {
            gameData.DealDamageToPlayer.Register(OnDamageToPlayer);
        }

        private void OnDisable()
        {
            gameData.DealDamageToPlayer.Unregister(OnDamageToPlayer);
        }

        private void OnDamageToPlayer()
        {
            gameData.PlayerHealth.Add(-gameData.EnemyDamage.Get());
            gameData.AudioData.PlayAudioEvent.Raise(gameData.BumpSound);
        }
    }
}
