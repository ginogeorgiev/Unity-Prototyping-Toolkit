using System;
using PrototypingToolkit.InputControls;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace PrototypingToolkit.Options.Controls
{
    public class InputRebindBehaviour : MonoBehaviour
    {
        [Header("Internal Refs")]
        [SerializeField] private Button keyButton;
        [SerializeField] private Button resetButton;

        [SerializeField] private TMP_Text inputDisplayText;

        [Header("Data")]
        [SerializeField] private InputRebindData inputRebindData;

        [Header("Settings")]
        [SerializeField] private InputActionReference inputAction;
        [SerializeField] private string bindingID;

        private InputActionRebindingExtensions.RebindingOperation rebindOperation;

        private void OnEnable()
        {
            if (keyButton) keyButton.onClick.AddListener(OpenRebindPopUp);
            if (resetButton) resetButton.onClick.AddListener(OnReset);

            if (!ResolveActionAndBinding()) return;
            SetDisplayText(inputAction.action, GetBindingIndex());
        }

        private void OnDisable()
        {
            if (keyButton) keyButton.onClick.RemoveListener(OpenRebindPopUp);
            if (resetButton) resetButton.onClick.RemoveListener(OnReset);
        }

        public void OnReset()
        {
            inputAction.action.RemoveBindingOverride(GetBindingIndex());
            SetDisplayText(inputAction.action, GetBindingIndex());
        }

        private void OnApply()
        {
            inputRebindData.CancelRebind.Unregister(OnCancel);
            inputRebindData.ApplyRebind.Unregister(OnApply);
        }
        
        private void OnCancel()
        {
            inputRebindData.InputActionReference.action.ApplyBindingOverride(GetBindingIndex(), inputRebindData.OriginalBinding);
            SetDisplayText(inputAction.action, GetBindingIndex());
            
            inputRebindData.CancelRebind.Unregister(OnCancel);
            inputRebindData.ApplyRebind.Unregister(OnApply);
        }
        
        private void OpenRebindPopUp()
        {
            if (!ResolveActionAndBinding()) return;
            
            inputRebindData.CancelRebind.Register(OnCancel);
            inputRebindData.ApplyRebind.Register(OnApply);
            
            // We do not rebind composites, each part of a composite needs to have its own InputRebindBehaviour
            DefineOperation();

            inputRebindData.CurrentRebindActionName.Set(inputAction.action.name);
            inputRebindData.EnableRebindPopUp.Raise();
            inputRebindData.RebindOperation.Start();
        }

        private void DefineOperation()
        {
            inputAction.action.Disable();

            int bindingIndex = GetBindingIndex();
            
            FillInputRebindData(bindingIndex);

            inputRebindData.RebindOperation = inputAction.action.PerformInteractiveRebinding(bindingIndex)
                .OnCancel(_ =>
                {
                    inputRebindData.DisableRebindPopUp.Raise();
                    inputAction.action.Enable();
                })
                .OnComplete(callback =>
                {
                    string key = callback.action.bindings[bindingIndex].ToDisplayString();

                    inputRebindData.SwitchToConcludeRebind.Raise();
                    inputRebindData.CurrentRebindKeyName.Set(key);
                    
                    SetDisplayText(key);

                    inputAction.action.Enable();
                });
        }

        private void FillInputRebindData(int bindingIndex)
        {
            inputRebindData.InputActionReference = inputAction;
            inputRebindData.BindingIndex = bindingIndex;

            inputRebindData.OriginalBinding = inputAction.action.bindings[GetBindingIndex()];
        }

        private bool ResolveActionAndBinding()
        {
            if (inputAction == null)
            {
                Debug.LogWarning($"inputAction has not been set in the inspector yet");
                return false;
            }

            if (string.IsNullOrEmpty(bindingID)) return false;

            int bindingIndex = -1;
            bindingIndex = GetBindingIndex();
            if (bindingIndex == -1)
            {
                Debug.LogError($"Cannot find binding with ID '{bindingID}' on '{inputAction}'");
                return false;
            }

            return true;
        }

        private int GetBindingIndex()
        {
            Guid bindingId = new Guid(bindingID);
            int bindingIndex = inputAction.action.bindings.IndexOf(x => x.id == bindingId);
            return bindingIndex;
        }

        private void SetDisplayText(InputAction inputAction, int bindingIndex)
        {
            inputDisplayText.text = inputAction.bindings[bindingIndex].ToDisplayString();
        }

        private void SetDisplayText(string text)
        {
            inputDisplayText.text = text;
        }
    }
}
