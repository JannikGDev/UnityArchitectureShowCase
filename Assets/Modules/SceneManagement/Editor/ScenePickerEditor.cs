using Assets.Modules.SceneManagement;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(ScenePicker), true)]
    public class ScenePickerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var picker = target as ScenePicker;
            var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(picker.scenePath);

            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            var newScene = EditorGUILayout.ObjectField("Scene", oldScene, typeof(SceneAsset), false) as SceneAsset;

            if (EditorGUI.EndChangeCheck())
            {
                var newPath = AssetDatabase.GetAssetPath(newScene);
                var scenePathProperty = serializedObject.FindProperty("scenePath");
                scenePathProperty.stringValue = newPath;
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
