using PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.UI
{
	public class SkillCoolDownUIController : MonoBehaviour
	{
		[Header("Game Data")]
		[SerializeField] private GameData gameData;
        
		[Header("Internal Refs")]
		[SerializeField] private Image bar;
        
		[Header("Debug")]
		[SerializeField] private float targetFillAmount;

		private void Update()
		{
			if (gameData.CurCoolDown.Get() <= gameData.SkillCoolDown.Get())
			{
				targetFillAmount = gameData.CurCoolDown.Get() / gameData.SkillCoolDown.Get();
				bar.fillAmount = targetFillAmount;
			}
		}
	}
}
