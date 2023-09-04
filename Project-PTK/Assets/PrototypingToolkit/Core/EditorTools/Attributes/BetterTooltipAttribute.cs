using UnityEngine;

namespace PrototypingToolkit.Core
{
	public class BetterTooltipAttribute : PropertyAttribute
	{
		public readonly string tooltip;

		public BetterTooltipAttribute(string tooltip)
		{
			this.tooltip = tooltip;
		}
	}
}
