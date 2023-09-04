using PrototypingToolkit.Core.PrimitiveTypes;
using TMPro;
using UnityEngine;

namespace PrototypingToolkit.Samples.Logic
{
	public class SampleEmptyClickListener : MonoBehaviour
	{
		[Header("Refs")]
		[SerializeField] private IntVariable clickAmount;
		[SerializeField] private TMP_Text tmp;

		private void OnEnable()
		{
			clickAmount.OnCurrentChanged.Register(OnClick);
			SetText();
		}

		private void OnDisable()
		{
			clickAmount.OnCurrentChanged.Unregister(OnClick);
		}

		private void OnClick()
		{
			SetText();
		}

		private void SetText()
		{
			tmp.text = clickAmount.ToString();
		}
	}
}
