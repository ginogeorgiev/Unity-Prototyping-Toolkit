using UnityEditor;
using UnityEngine;

namespace PrototypingToolkit.Core
{
    public abstract class FeatureData : ScriptableObject
    {
        [SerializeField] private FeatureDomain featureDomain;

        public bool logEvent { get; set; }
        public Color logColor { get; set; }

        public FeatureDomain FeatureDomain
        {
            get => featureDomain;
            set => featureDomain = value;
        }

        private void OnEnable()
        {
            if (!featureDomain)
            {
                #if UNITY_EDITOR
                string assetPath = AssetDatabase.GetAssetPath(this);
                if (assetPath.Contains("DEFAULT.asset"))
                {
                    featureDomain = AssetDatabase
                        .LoadAssetAtPath<FeatureDomain>("Assets/PrototypingToolkit/FeatureDomains/DEFAULT.asset");
                }
                #endif
            }
        }
    }
}
