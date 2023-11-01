using System.Collections;
using PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.Skills
{
	public class DamageSkillController : MonoBehaviour
	{
		[Header("Data")]
		[SerializeField] private GameData gameData;
		
		[Header("Internal Ref")]
		[SerializeField] private GameObject damageDealer;
		
		[Header("Debug")]
		[SerializeField] private bool isPressed;

		private void OnEnable()
		{
			gameData.SkillInput.action.Enable();
			
			gameData.SkillInput.action.started += OnSkillInput;
			gameData.SkillInput.action.canceled += OnSkillInput;

			damageDealer.SetActive(false);
		}

		private void OnDisable()
		{
			gameData.SkillInput.action.started -= OnSkillInput;
			gameData.SkillInput.action.canceled -= OnSkillInput;
			
			gameData.SkillInput.action.Disable();
		}
		
		private void OnSkillInput(InputAction.CallbackContext context)
		{
			isPressed = context.started;
		}

		private void Update()
		{
			if (gameData.CurCoolDown.Get() > 0)
			{
				gameData.CurCoolDown.Add(- Time.deltaTime);
			}
			else if (isPressed)
			{
				DoSkill();
			}
		}

		private void DoSkill()
		{
			if (!(gameData.CurCoolDown.Get() <= 0)) return;

			StartCoroutine(DealDamage());
		}

		private IEnumerator DealDamage()
		{
			damageDealer.SetActive(true);
			gameData.AudioData.PlayAudioEvent.Raise(gameData.SkillSound);
			RefreshCoolDown();

			yield return new WaitForSeconds(gameData.SkillActiveTime.Get());
			
			damageDealer.SetActive(false);
		}

		private void RefreshCoolDown()
		{
			gameData.CurCoolDown.Set(gameData.SkillCoolDown.Get());
		}
	}
}
