using UnityEngine;

namespace PrototypingToolkit.Core
{
	[CreateAssetMenu(
		menuName = PTK_MenuNames.MN_FT,
		fileName = PTK_MenuNames.FN_FT,
		order = PTK_MenuNames.O_FT
	)]
	
	public class FeatureDomain : ScriptableObject
	{
		[BetterTooltip("Choose your Feature Domain and give it a proper description." +
		               "\n Need a new one?" +
		               "\n Right-click: Create/PrototypingToolkit/FeatureDomain " +
		               "\n For more info have a look at the Documentation.")]
		[TextArea(1,4)] [SerializeField] private string description;
		
		[SerializeField] private bool logEvent;
		[SerializeField] private Color logColor;
		
		public bool LogEvent => logEvent;
		public Color LogColor => logColor;
	}
}
