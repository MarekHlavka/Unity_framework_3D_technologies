using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;


#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build;


public class PlatformSwitchController : MonoBehaviour, IActiveBuildTargetChanged
{

    // Android IL2CPP
    // Windows Mono2x


    [SerializeField]
    private TargetPlatform platform;
    public TargetPlatform Platfrom => platform;

    [Header("Windows settings")]
    [SerializeField]
    private GameObject windows_cameras;
    [SerializeField]
    private GameObject windows_UI;

    [Header("Android settings")]
    [SerializeField]
    private GameObject android_cameras;
    [SerializeField]
    private GameObject android_UI;

    public void testClick()
    {
        string _text = "Switching from: " + EditorUserBuildSettings.activeBuildTarget.ToString();
        Debug.Log(_text);

        if (platform == TargetPlatform.Android)
        {
            //PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.Mono2x);
            //EditorUserBuildSettings.SwitchActiveBuildTargetAsync(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64);
            platform = TargetPlatform.Windows;
            
        }
        else
        {
            //PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
            //EditorUserBuildSettings.SwitchActiveBuildTargetAsync(BuildTargetGroup.Android, BuildTarget.Android);
            platform = TargetPlatform.Android;
        }

        SwitchActiveCameras(platform);
        SwitchActiveUI(platform);
        GetComponent<GameControler>().SetPlatform(platform);
    }

    public int callbackOrder { get { return 0; } }
    public void OnActiveBuildTargetChanged(BuildTarget previousTarget, BuildTarget newTarget)
    {
        Debug.Log("Active platform is now " + newTarget);
    }

    // Switch active platforms Windows vs Android
    private void SwitchActiveCameras(TargetPlatform platform)
    {
        windows_cameras.SetActive(platform == TargetPlatform.Windows);
        android_cameras.SetActive(platform == TargetPlatform.Android);
    }
    private void SwitchActiveUI(TargetPlatform platform)
    {
        windows_UI.SetActive(platform == TargetPlatform.Windows);
        android_UI.SetActive(platform == TargetPlatform.Android);
    }
}

#endif
