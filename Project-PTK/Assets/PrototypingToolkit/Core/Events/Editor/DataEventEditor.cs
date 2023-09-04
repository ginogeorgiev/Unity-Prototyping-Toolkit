using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PrototypingToolkit.Core.Editor
{
    [CustomEditor(typeof(DataEvent<>), true)]
    public class DataEventEditor : UnityEditor.Editor
    {
        private object eventData;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawDefaultInspector();

            EditorGUILayout.Space();

            eventData = EditorGUILayout.ObjectField("Event Data", (Object)eventData, typeof(object), true);

            if (GUILayout.Button("Raise Event"))
            {
                RaiseEvent();
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void RaiseEvent()
        {
            ScriptableObject dataEvent = (ScriptableObject)target;
            MethodInfo method = dataEvent.GetType().GetMethod("Raise");

            if (method != null)
            {
                method.Invoke(dataEvent, new object[] { eventData });
            }
        }
    }
}
