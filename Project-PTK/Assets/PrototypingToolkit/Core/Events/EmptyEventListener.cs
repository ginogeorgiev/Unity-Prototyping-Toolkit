using MyBox;
using UnityEngine;
using UnityEngine.Events;

namespace PrototypingToolkit.Core
{
    public class EmptyEventListener : MonoBehaviour
    {
        [SerializeField] private EmptyEvent @event;
        [SerializeField] private UnityEvent response;

        private void OnEnable()
        {
            @event.Register(this);
        }

        private void OnDisable()
        {
            @event.Unregister(this);
        }

        public void OnEventRaised()
        {
            response.Invoke();
        }
        
        #if UNITY_EDITOR
        [ButtonMethod]
        private void Raise()
        {
            @event.Raise();
        }
        #endif
    }
}
