// using PrototypingToolkit.Core.Logic.Event;
// using UnityEditor;
// using UnityEngine;
//
// [CustomEditor(typeof(EventHub))]
// public class EventHubDrawer : Editor
// {
//     public override void OnInspectorGUI()
//     {
//         serializedObject.Update();
//
//         SerializedProperty eventChannelsProperty = serializedObject.FindProperty("eventChannels");
//
//         EditorGUILayout.LabelField("Event Channels");
//
//         EditorGUILayout.BeginHorizontal();
//
//         int count = eventChannelsProperty.arraySize;
//
//         for (int i = 0; i < count; i++)
//         {
//             EditorGUILayout.PropertyField(eventChannelsProperty.GetArrayElementAtIndex(i), GUIContent.none);
//         }
//
//         EditorGUILayout.EndHorizontal();
//
//         if (GUILayout.Button("+"))
//         {
//             eventChannelsProperty.arraySize++;
//         }
//
//         if (count > 0 && GUILayout.Button("-"))
//         {
//             eventChannelsProperty.arraySize--;
//         }
//
//         serializedObject.ApplyModifiedProperties();
//     }
// }
