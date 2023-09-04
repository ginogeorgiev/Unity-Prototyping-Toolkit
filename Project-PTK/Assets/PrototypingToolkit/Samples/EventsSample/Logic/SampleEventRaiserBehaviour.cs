using MyBox;
using UnityEngine;

namespace PrototypingToolkit.Samples.Logic
{
    public class SampleEventRaiserBehaviour : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private SampleEventDataContainer eventDataContainer;
        
        [Header("External Refs - only necessary for this demo")]
        [SerializeField] private SampleEventCubeBehaviour sampleCubeBehaviour;
		
        [ButtonMethod]
        private void RaiseEmptyOnEvent()
        {
            eventDataContainer.On.Raise();
        }
		
        [ButtonMethod]
        private void RaiseEmptyOffEvent()
        {
            eventDataContainer.Off.Raise();
        }

        [ButtonMethod]
        private void RaiseDataOnEvent()
        {
            eventDataContainer.GOOn.Raise(sampleCubeBehaviour);
        }
		
        [ButtonMethod]
        private void RaiseDataOffEvent()
        {
            eventDataContainer.GOOff.Raise(sampleCubeBehaviour);
        }
    }
}
