using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LeiaMedia))]
public class LeiaMediaEditor : Editor
{
    public override void OnInspectorGUI()
    {
        foreach (var targetObj in targets)
        {
            SerializedObject serializedObj = new SerializedObject(targetObj);
            SerializedProperty mediaTypeProp = serializedObj.FindProperty("mediaType");
            SerializedProperty sbsTextureProp = serializedObj.FindProperty("sbsTexture");
            SerializedProperty videoPlayerProp = serializedObj.FindProperty("videoPlayer");

            serializedObj.Update();

            EditorGUILayout.PropertyField(mediaTypeProp);

            switch (mediaTypeProp.enumValueIndex)
            {
                case 0:
                    EditorGUILayout.PropertyField(sbsTextureProp);
                    break;
                case 1:
                    EditorGUILayout.PropertyField(videoPlayerProp);
                    break;
            }

            serializedObj.ApplyModifiedProperties();
        }
    }
}