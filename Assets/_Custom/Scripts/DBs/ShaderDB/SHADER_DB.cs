using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Class for pseudo DB
public class SHADER_DB : MonoBehaviour
{
    public  List<ShaderDBItemEditor> shadersList = new List<ShaderDBItemEditor>();
    [Header("Add new shader")]
    [SerializeField] private string newShaderName;
    [SerializeField] private string newShaderDescription;
    [SerializeField] private Shader newShader;

    // Adding new shader in editor before build
    public void AddNewShader()
    {
        if (newShaderName == null || newShaderDescription == null || newShader == null)
        {
            return;
        }
        ShaderDBItemEditor newShaderitem = new ShaderDBItemEditor(newShaderName, newShaderDescription, newShader);
        shadersList.Add(newShaderitem);
        newShaderName = null;
        newShaderDescription = null;
        newShader = null;
    }
}

// Modified Custom Inspector for SHADER DB
#if UNITY_EDITOR
[CustomEditor(typeof(SHADER_DB))]
public class SHADER_DB_Editor : Editor{
    public override void OnInspectorGUI()
    {
        SHADER_DB db = (SHADER_DB)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("New Shader");
        if (GUILayout.Button("Add shader")) {
            db.AddNewShader();
        }
        
    }
}
#endif