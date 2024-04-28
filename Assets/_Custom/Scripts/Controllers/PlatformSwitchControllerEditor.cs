using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;



[CustomEditor(typeof(PlatformSwitchController))]
public class GameControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlatformSwitchController controler = (PlatformSwitchController)target;

        base.OnInspectorGUI();

        string platform = (controler.Platfrom == TargetPlatform.Windows) ? "PC" : "Android";
        EditorGUILayout.LabelField("Current platform: " + platform);

        EditorGUILayout.LabelField("IMPORTANT! - check build setting, if it has same target platform");
        if (GUILayout.Button("Toggle platforms"))
        {
            controler.testClick();
        }
    }
}
#endif
