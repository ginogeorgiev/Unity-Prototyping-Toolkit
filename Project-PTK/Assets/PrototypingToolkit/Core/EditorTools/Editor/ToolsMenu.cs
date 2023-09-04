using UnityEditor;
using UnityEngine;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

namespace PrototypingToolkit.Core.Editor
{
    public class ToolsMenu : MonoBehaviour
    {
        [MenuItem("PrototypingToolkit/Setup/Create Feature Folder")]
        public static void CreateFeatureFolder()
        {
            NewDir("Features", "FeatureA");
            NewDir("Features/FeatureA", "Art", "Data", "Logic", "Prefabs");
            Refresh();
        }

        private static void NewDir(string root, params string[] dirs)
        {
            var fullPath = Combine(dataPath, root);
            foreach (var newDir in dirs)
            {
                CreateDirectory(Combine(fullPath, newDir));
            }
        }
    }
}
