using System.Linq;
using PrototypingToolkit.Options.Controls;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace PrototypingToolkit.UI.Options.Controls.Editor
{
    [CustomEditor(typeof(InputRebindBehaviour))]
    public class InputRebindBehaviourEditor : UnityEditor.Editor
    {
        private SerializedProperty inputRebindDataProperty;
        
        private SerializedProperty inputActionProperty;
        private SerializedProperty bindingIDProperty;
        
        private SerializedProperty keyButtonProperty;
        private SerializedProperty resetButtonProperty;
        private SerializedProperty inputDisplayTextProperty;

        private readonly GUIContent bindingLabel = new ("Binding");
        private GUIContent[] bindingOptions;
        private string[] bindingOptionValues;
        private int selectedBindingOption;
        
        protected void OnEnable()
        {
            inputRebindDataProperty = serializedObject.FindProperty("inputRebindData");
            inputActionProperty = serializedObject.FindProperty("inputAction");
            bindingIDProperty = serializedObject.FindProperty("bindingID");
            keyButtonProperty = serializedObject.FindProperty("keyButton");
            resetButtonProperty = serializedObject.FindProperty("resetButton");
            inputDisplayTextProperty = serializedObject.FindProperty("inputDisplayText");

            RefreshBindingOptions();
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.PropertyField(inputRebindDataProperty);
            
            EditorGUILayout.PropertyField(keyButtonProperty);
            EditorGUILayout.PropertyField(resetButtonProperty);
            EditorGUILayout.PropertyField(inputDisplayTextProperty);
            
            EditorGUILayout.PropertyField(inputActionProperty);
            
            int newSelectedBinding = EditorGUILayout.Popup(bindingLabel, selectedBindingOption, bindingOptions);
            if (newSelectedBinding != selectedBindingOption)
            {
                string bindingId = bindingOptionValues[newSelectedBinding];
                bindingIDProperty.stringValue = bindingId;
                selectedBindingOption = newSelectedBinding;
            }
            
            RefreshBindingOptions();
            
            serializedObject.ApplyModifiedProperties();
        }

        private void RefreshBindingOptions()
        {
            InputActionReference actionReference = (InputActionReference)inputActionProperty.objectReferenceValue;
            InputAction action = actionReference?.action;

            if (action == null)
            {
                bindingOptions = new GUIContent[0];
                bindingOptionValues = new string[0];
                selectedBindingOption = -1;
                return;
            }

            ReadOnlyArray<InputBinding> bindings = action.bindings;
            int bindingCount = bindings.Count;

            bindingOptions = new GUIContent[bindingCount];
            bindingOptionValues = new string[bindingCount];
            selectedBindingOption = -1;

            string currentBindingId = bindingIDProperty.stringValue;
            for (int i = 0; i < bindingCount; ++i)
            {
                InputBinding binding = bindings[i];
                string bindingId = binding.id.ToString();
                bool haveBindingGroups = !string.IsNullOrEmpty(binding.groups);

                // If we don't have a binding groups (control schemes), show the device that if there are, for example,
                // there are two bindings with the display string "A", the user can see that one is for the keyboard
                // and the other for the gamepad.
                InputBinding.DisplayStringOptions displayOptions =
                    InputBinding.DisplayStringOptions.DontUseShortDisplayNames | InputBinding.DisplayStringOptions.IgnoreBindingOverrides;
                
                if (!haveBindingGroups) displayOptions |= InputBinding.DisplayStringOptions.DontOmitDevice;

                // Create display string.
                string displayString = action.GetBindingDisplayString(i, displayOptions);

                // If binding is part of a composite, include the part name.
                if (binding.isPartOfComposite)
                    displayString = $"{ObjectNames.NicifyVariableName(binding.name)}: {displayString}";

                // Some composites use '/' as a separator. When used in popup, this will lead to to submenus. Prevent
                // by instead using a backlash.
                displayString = displayString.Replace('/', '\\');

                // If the binding is part of control schemes, mention them.
                if (haveBindingGroups)
                {
                    InputActionAsset asset = action.actionMap?.asset;
                    if (asset != null)
                    {
                        var controlSchemes = string.Join(", ",
                            binding.groups.Split(InputBinding.Separator)
                                .Select(x => asset.controlSchemes.FirstOrDefault(c => c.bindingGroup == x).name));

                        displayString = $"{displayString} ({controlSchemes})";
                    }
                }

                bindingOptions[i] = new GUIContent(displayString);
                bindingOptionValues[i] = bindingId;

                if (currentBindingId == bindingId) selectedBindingOption = i;
            }
        }
    }
}
