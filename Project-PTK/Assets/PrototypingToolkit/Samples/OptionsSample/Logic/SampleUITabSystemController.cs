using UnityEngine;
using UnityEngine.UI;

namespace PrototypingToolkit.Samples
{
	public class SampleUITabSystemController : MonoBehaviour
	{
		[Header("Internal Refs")]
		[SerializeField] private Button audioButton;
		[SerializeField] private Button controlsButton;
		
		[Header("External Refs")]
		[SerializeField] private GameObject audioCanvas;
		[SerializeField] private GameObject controlCanvas;

		private void OnEnable()
		{
			controlCanvas.SetActive(false);
			audioCanvas.SetActive(false);
			
			audioButton.onClick.AddListener(ChooseAudioTab);
			controlsButton.onClick.AddListener(ChooseControlsTab);
		}

		private void ChooseAudioTab()
		{
			audioCanvas.SetActive(true);
			
			controlCanvas.SetActive(false);
		}

		private void ChooseControlsTab()
		{
			controlCanvas.SetActive(true);
			
			audioCanvas.SetActive(false);
		}
	}
}
