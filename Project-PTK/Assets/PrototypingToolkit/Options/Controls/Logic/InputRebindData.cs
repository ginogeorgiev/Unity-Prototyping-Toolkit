using PrototypingToolkit.Core;
using PrototypingToolkit.Core.PrimitiveTypes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingToolkit.InputControls
{
	[CreateAssetMenu(
		menuName = PTK_MenuNames.MN_IRD,
		fileName = PTK_MenuNames.FN_IRD,
		order = PTK_MenuNames.O_INPUT)]
	public class InputRebindData : ScriptableObject
	{
		[Header("Data")]
		[SerializeField] private StringVariable currentRebindActionName;
		[SerializeField] private StringVariable currentRebindKeyName;
		
		[SerializeField] private EmptyEvent enableRebindPopUp;
		[SerializeField] private EmptyEvent disableRebindPopUp;
		[SerializeField] private EmptyEvent switchToStartRebind;
		[SerializeField] private EmptyEvent switchToConcludeRebind;
		
		[SerializeField] private EmptyEvent cancelRebind;
		[SerializeField] private EmptyEvent captureRebind;
		[SerializeField] private EmptyEvent applyRebind;

		public StringVariable CurrentRebindActionName => currentRebindActionName;
		public StringVariable CurrentRebindKeyName => currentRebindKeyName;

		public EmptyEvent EnableRebindPopUp => enableRebindPopUp;
		public EmptyEvent DisableRebindPopUp => disableRebindPopUp;
		
		public EmptyEvent SwitchToStartRebind => switchToStartRebind;
		public EmptyEvent SwitchToConcludeRebind => switchToConcludeRebind;
		
		public EmptyEvent CancelRebind => cancelRebind;
		public EmptyEvent CaptureRebind => captureRebind;
		public EmptyEvent ApplyRebind => applyRebind;

		public InputActionRebindingExtensions.RebindingOperation RebindOperation { get; set; }
		public InputActionReference InputActionReference { get; set; }
		
		public InputBinding OriginalBinding { get; set; }
		
		public int BindingIndex { get; set; }
		
		public void CleanUp()
		{
			InputActionReference = null;
			BindingIndex = -1;
			RebindOperation = null;
			RebindOperation?.Dispose();
		}
	}
}
