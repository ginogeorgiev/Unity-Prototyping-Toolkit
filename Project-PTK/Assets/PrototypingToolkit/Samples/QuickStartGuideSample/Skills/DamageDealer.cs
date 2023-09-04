using UnityEngine;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.Skills
{
    public class DamageDealer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) return;

            Destroy(other.transform.parent.gameObject);
        }
    }
}
