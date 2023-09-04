using UnityEngine;
using UnityEngine.Events;

namespace PrototypingToolkit.Core.Extensions
{
    public sealed class WaitUntilUnityEvent : CustomYieldInstruction
    {
        private UnityEvent unityEvent;
        private bool eventTriggered;

        public WaitUntilUnityEvent(UnityEvent unityEvent)
        {
            this.unityEvent = unityEvent;
            unityEvent.AddListener(OnEventTriggered);
        }

        public override bool keepWaiting => !eventTriggered;

        private void OnEventTriggered()
        {
            eventTriggered = true;
            unityEvent.RemoveListener(OnEventTriggered);
        }
    }
}
