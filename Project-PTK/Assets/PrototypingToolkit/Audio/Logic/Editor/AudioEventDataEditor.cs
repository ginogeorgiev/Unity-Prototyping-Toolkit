using UnityEditor;
using UnityEngine;

namespace PrototypingToolkit.Audio
{
	[CustomEditor(typeof(AudioEventData), true)]
	public class AudioEventDataEditor : Editor
	{
		[SerializeField] private AudioSource _previewer;

		public void OnEnable()
		{
			_previewer = EditorUtility
				.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource))
				.GetComponent<AudioSource>();
		}

		public void OnDisable()
		{
			DestroyImmediate(_previewer.gameObject);
		}

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
			if (GUILayout.Button("Preview"))
			{
				((AudioEventData) target).Play(_previewer, out AudioClipData audioClipData);
			}
			EditorGUI.EndDisabledGroup();
		}
	}
}
