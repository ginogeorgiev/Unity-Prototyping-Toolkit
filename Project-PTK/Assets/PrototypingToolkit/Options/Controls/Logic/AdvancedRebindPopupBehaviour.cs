using PrototypingToolkit.InputControls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypingToolkit.Options.Controls
{
	public class AdvancedRebindPopupBehaviour : MonoBehaviour
	{
		[Header("Data")]
		[SerializeField] private InputRebindData inputRebindData;
		
		[Header("Internal Ref")]
		[SerializeField] private GameObject popUp;
		[SerializeField] private GameObject startRebind;
		[SerializeField] private GameObject concludeRebind;
		
		[SerializeField] private Button cancelButton;
		[SerializeField] private Button captureButton;
		[SerializeField] private Button applyButton;
		
		[SerializeField] private TMP_Text actionName;
		[SerializeField] private TMP_Text key;

		private void OnEnable()
		{
			inputRebindData.CurrentRebindActionName.OnCurrentChanged.Register(OnSetActionName);
			inputRebindData.CurrentRebindKeyName.OnCurrentChanged.Register(OnSetKeyName);
			
			inputRebindData.SwitchToStartRebind.Register(SwitchToStartRebind);
			inputRebindData.SwitchToConcludeRebind.Register(SwitchToConcludeRebind);
			
			inputRebindData.EnableRebindPopUp.Register(EnablePopUp);
			inputRebindData.DisableRebindPopUp.Register(DisablePopUp);

			popUp.SetActive(false);
		}
		
		private void OnDisable()
		{
			inputRebindData.SwitchToStartRebind.Unregister(SwitchToStartRebind);
			inputRebindData.SwitchToConcludeRebind.Unregister(SwitchToConcludeRebind);
			
			inputRebindData.SwitchToStartRebind.Unregister(SwitchToStartRebind);
			inputRebindData.SwitchToConcludeRebind.Unregister(SwitchToConcludeRebind);
			
			inputRebindData.EnableRebindPopUp.Unregister(EnablePopUp);
			inputRebindData.DisableRebindPopUp.Unregister(DisablePopUp);
		}

		private void OnSetActionName()
		{
			actionName.text = inputRebindData.CurrentRebindActionName.Get();
		}

		private void OnSetKeyName()
		{
			key.text = inputRebindData.CurrentRebindKeyName.Get();
		}

		private void EnablePopUp()
		{
			SwitchToStartRebind();
			popUp.SetActive(true);
		}

		private void DisablePopUp()
		{
			inputRebindData.CleanUp();
			popUp.SetActive(false);
		}

		public void OnCancel()
		{
			inputRebindData.RebindOperation.Start();
			inputRebindData.CancelRebind.Raise();
			inputRebindData.RebindOperation.Cancel();
			DisablePopUp();
		}

		public void OnCapture()
		{
			SwitchToStartRebind();
			inputRebindData.RebindOperation.Start();
		}

		public void OnApply()
		{
			//TODO: fix esc on capture or apply override later when apply really happens not earlier
			DisablePopUp();
			inputRebindData.ApplyRebind.Raise();
		}

		private void SwitchToStartRebind()
		{
			startRebind.SetActive(true);
			concludeRebind.SetActive(false);
		}

		private void SwitchToConcludeRebind()
		{
			startRebind.SetActive(false);
			concludeRebind.SetActive(true);
		}
	}
}
