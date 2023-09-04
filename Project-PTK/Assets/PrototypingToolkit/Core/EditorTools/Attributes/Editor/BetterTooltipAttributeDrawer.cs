using MyBox.EditorTools;
using UnityEditor;
using UnityEngine;

namespace PrototypingToolkit.Core
{
    [CustomPropertyDrawer(typeof(BetterTooltipAttribute))]
    public class BetterTooltipAttributeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            BetterTooltipAttribute tooltipAttribute = (BetterTooltipAttribute)attribute;
            string content = tooltipAttribute.tooltip;

            Rect tooltipIconRect = new Rect(position.x, position.y, 18, position.height);
            Rect propertyRect = new Rect(position.x + 18, position.y, position.width - 18, position.height);

            EditorGUI.PropertyField(propertyRect, property, label);

            DrawTooltipIcon();

            EditorGUI.EndProperty();

            void DrawTooltipIcon()
            {
                string tooltip = $"{content}";
                GUIContent tooltipContent = new GUIContent(MyGUI.EditorIcons.Help);
                tooltipContent.tooltip = tooltip;

                EditorGUI.LabelField(tooltipIconRect, tooltipContent, EditorStyles.label);
            }
        }
    }
}
