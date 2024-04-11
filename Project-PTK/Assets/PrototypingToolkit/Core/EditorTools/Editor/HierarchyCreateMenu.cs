using UnityEditor;
using UnityEngine;

namespace PrototypingToolkit.Core.Editor
{
    public static class HierarchyCreateMenu
    {
        private const string BasePrefabPath = "Assets/Prototypingtoolkit";
        private static readonly GameObject[] PrefabPaths =
        {
            AssetDatabase.LoadAssetAtPath<GameObject>(BasePrefabPath + "/Cameras/RTSCamera/RTS_Camera.prefab"),
            AssetDatabase.LoadAssetAtPath<GameObject>(BasePrefabPath + "/UI/EventSystem.prefab"),
            AssetDatabase.LoadAssetAtPath<GameObject>(BasePrefabPath + "/Audio/Prefabs/AudioManager.prefab"),
            AssetDatabase.LoadAssetAtPath<GameObject>(BasePrefabPath + "/Options/Audio/Prefabs/AudioDataManager.prefab"),
            AssetDatabase.LoadAssetAtPath<GameObject>(BasePrefabPath + "/Core/Events/EmptyEventListener.prefab")
        };

        [MenuItem("GameObject/PrototypingToolkit/RTSCamera", false, 12)]
        public static void CreateRTSCamera(MenuCommand menuCommand)
        {
            CreatePrefabInstance(menuCommand, PrefabPaths[0]);
        }

        [MenuItem("GameObject/PrototypingToolkit/EventSystem", false, 11)]
        public static void CreateEventSystem(MenuCommand menuCommand)
        {
            CreatePrefabInstance(menuCommand, PrefabPaths[1]);
        }

        [MenuItem("GameObject/PrototypingToolkit/AudioManager", false, 11)]
        public static void CreateAudioManager(MenuCommand menuCommand)
        {
            CreatePrefabInstance(menuCommand, PrefabPaths[2]);
        }

        [MenuItem("GameObject/PrototypingToolkit/Audio Settings Manager", false, 11)]
        public static void CreateAudioDataManager(MenuCommand menuCommand)
        {
            CreatePrefabInstance(menuCommand, PrefabPaths[3]);
        }

        [MenuItem("GameObject/PrototypingToolkit/Empty Event Listener", false, 11)]
        public static void CreateEmptyEventListener(MenuCommand menuCommand)
        {
            CreatePrefabInstance(menuCommand, PrefabPaths[4]);
        }

        // Add more methods for other prefabs as needed

        private static void CreatePrefabInstance(MenuCommand menuCommand, GameObject prefab)
        {
            if (prefab != null)
            {
                GameObject instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;

                if (menuCommand.context is GameObject parentObject)
                {
                    GameObjectUtility.SetParentAndAlign(instance, parentObject);
                }

                Undo.RegisterCreatedObjectUndo(instance, "Create " + instance.name);
                Selection.activeObject = instance;
            }
            else
            {
                Debug.LogWarning("Prefab not found.");
            }
        }
    }
}
