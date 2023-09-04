using PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.UI
{
    public class HealthBarUIController : MonoBehaviour
    {
        [Header("Game Data")]
        [SerializeField] private GameData gameData;
        
        [Header("Internal Refs")]
        [SerializeField] private Image bar;
        
        [Header("Debug")]
        [SerializeField] private float targetFillAmount;

        private void OnEnable()
        {
            gameData.PlayerHealth.OnCurrentChanged.Register(OnPlayerHealthChanged);
            
            OnPlayerHealthChanged();
        }

        private void OnDisable()
        {
            gameData.PlayerHealth.OnCurrentChanged.Unregister(OnPlayerHealthChanged);
        }

        private void OnPlayerHealthChanged()
        {
            targetFillAmount = gameData.PlayerHealth.Get() / gameData.PlayerHealth.StartValue;
            bar.fillAmount = targetFillAmount;
        }
    }
}
