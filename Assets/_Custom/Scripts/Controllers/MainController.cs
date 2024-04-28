using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [SerializeField] private Player playerObject;

    [Header("Cameras")]
    [SerializeField] private GameObject[] windowsPostProcessInterfaces;
    [SerializeField] private GameObject[] androidPostProcessInterfaces;
    [SerializeField] private GameObject menuCamera;

    [Header("UI Butons")]
    [SerializeField] private Button runButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button toggleShadersButton;
    [SerializeField] private Button openShaderDB;
    [SerializeField] private Button openLevelDB;
    [SerializeField] private Button toggleJoystickUIButton;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button showLastResults;

    [Header("Controllers")]
    [SerializeField] private RunLevelLoader runLevelLoader;

    [Header("User Inerfaces")]
    [SerializeField] private GameObject ShaderDB;
    [SerializeField] private ShaderMenuScrollController shaderMenuScrollController;
    [SerializeField] private GameObject levelDB; //
    [SerializeField] private DeviceSettingsPanelController deviceSettingsPanelController;
    [SerializeField] private GameObject JoystickUI;
    [SerializeField] private GameObject NextLevelUI;
    [SerializeField] private AllowMovement moveController;
    [SerializeField] private LevelShowScrollController levelShowScrollController;
    [SerializeField] private TargetGameObjectController targetGameObjectController;
    [SerializeField] private LastReportController lastReportController;


    [SerializeField] private Shader[] postProcessShaders;
    [SerializeField] private TMP_Dropdown targetUIDropdown;


    private List<Material> materials = new List<Material>();
    private TargetPlatform targetPlatform;
    private GameObject activeCamera;
    private bool shadersActive = false;
    private GameObject activeLevel = null;
    private NextLevelUIController nextLevelUIController;

    private LevelInterface lastLevel;
    private string lastRunReport = "";

    // Start is called before the first frame update
    void Start()
    {
        nextLevelUIController = NextLevelUI.GetComponent<NextLevelUIController>();
        // Aquiring active plarform for current build
        targetPlatform = GetComponent<GameControler>().GetPlatform();

        for (int i = 0; i < postProcessShaders.Length; i++)
        {
            materials.Add(new Material(postProcessShaders[i]));
        }

        AddDropDownOptions(
            (targetPlatform == TargetPlatform.Windows) ?
            windowsPostProcessInterfaces : androidPostProcessInterfaces);
        //AddDropDownOptions(androidPostProcessInterfaces);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////// REDO PLATFORM SELECTION ///////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // AddDropDownOptions(windowsPostProcessInterfaces);




        runButton.onClick.AddListener(Run);
        exitButton.onClick.AddListener(delegate { Exit(); });
        exitButton.enabled = false;
        toggleShadersButton.onClick.AddListener(toggleSahders);
        openShaderDB.onClick.AddListener(OpenShaderDB);
        openLevelDB.onClick.AddListener(OpenLevelDB);
        toggleJoystickUIButton.onClick.AddListener(ToggleJoystickUIFunc);
        showLastResults.onClick.AddListener(ShowLastResults);

        JoystickUI.SetActive(targetPlatform != TargetPlatform.Windows);

        InitilazeCameraObjects(windowsPostProcessInterfaces);
        InitilazeCameraObjects(androidPostProcessInterfaces);

        if (Display.displays.Length > 1)
        {
            // Activate the display 1 (second monitor connected to the system).
            Display.displays[1].Activate();
        }
    }

    private void InitilazeCameraObjects(GameObject[] objects)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
    }

    private void AddDropDownOptions(GameObject[] options)
    {
        targetUIDropdown.options.Clear();
        if (options.Length > 0)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Debug.Log(options[i].name);
                targetUIDropdown.options.Add(new TMP_Dropdown.OptionData(options[i].name.ToString()));

            }
            targetUIDropdown.GetComponentInChildren<TMP_Text>().text = options[0].name.ToString();
        }

    }
    // ------------------------------------------------------------------------------------------------
    // ----------------------------------------- Buton functions --------------------------------------
    // ------------------------------------------------------------------------------------------------
    private void Run()
    {
        lastRunReport = "";
        lastReportController.SetText(lastRunReport);
        LoadNextLevel(initialRun: true);

    }

    private void LoadNextLevel(bool initialRun = false)
    {

        
        var lastCompletedIndex = runLevelLoader.GetLastCompletedLevelIndex();


        // REDO HERE
        LevelInterface lastCompletedLevel = lastLevel;

        (LevelInterface nextLevel, string currentLevelName, string nextLevelName) = runLevelLoader.GetNextLoadedLevel();
        NextLevelUI.GetComponent<NextLevelUIController>().SetButtonText(nextLevelName == null ? "Exit tests!" : "Next Level");

        if (nextLevel != null)
        {
            if (activeCamera != null) { Destroy(activeLevel); }
            activeLevel = Instantiate(nextLevel.GetRootGameObject());
            activeLevel.SetActive(true);

            // Reset camera object
            playerObject.transform.position = nextLevel.GetStartPosition();
            playerObject.transform.LookAt(Vector3.forward);

            /// problem with not first level
            /// cretae loop until names are correct
            /// LevelInterface loadedLevel = (LevelInterface)activeLevel.GetComponent(nextLevel.GetLevelType());
            LevelInterface loadedLevel = null;

            LevelInterface[] potentialLoadedLevels = activeLevel.GetComponents<LevelInterface>();
            foreach (LevelInterface level in potentialLoadedLevels)
            {
                if(level.GetLevelName() == currentLevelName)
                {
                    loadedLevel = level;
                    break;
                }
            }


            lastLevel = loadedLevel;

            bool canMove = loadedLevel.GetLevelType() == typeof(LevelFreeLook);
            playerObject.setAllowMovement(canMove);
            moveController.SetCheckmark(canMove);
            targetGameObjectController.LoadLevel(loadedLevel);

            LevelWithMoveDirection possibleMoveLevel = loadedLevel.GetComponent<LevelWithMoveDirection>();
            if (possibleMoveLevel != null)
            {
                possibleMoveLevel.SetPlayer(playerObject);
            }

            nextLevelButton.onClick.RemoveAllListeners();
            nextLevelButton.onClick.AddListener(nextLevelName == null ? delegate { Exit(true); } : delegate { LoadNextLevel(); });
            nextLevelUIController.updateTexts(currentLevelName, nextLevelName);

            if (initialRun)
            {
                /// TODO not turn off when target display is not 0
                if (!checkDisplayZeroCameras())
                {
                    menuCamera.SetActive(false);
                }

                exitButton.enabled = true;
                runButton.enabled = false;
                NextLevelUI.SetActive(true);
                activeCamera = (targetPlatform == TargetPlatform.Windows) ?
                    windowsPostProcessInterfaces[targetUIDropdown.value] :
                    androidPostProcessInterfaces[targetUIDropdown.value];
                activeCamera.SetActive(true);

                deviceSettingsPanelController.Load(activeCamera.GetComponent<DeviceSettingsInterface>());

                levelShowScrollController.ResetColors();
            }
            else
            {

                /// ADD Return report as well
                if (lastCompletedIndex != null)
                {
                    levelShowScrollController.LevelCompleted(lastCompletedIndex.Value);
                }
                if (lastCompletedLevel != null)
                {
                    lastRunReport += "######################################\n" + lastCompletedLevel.GetReport();
                }
            }
        }
    }

    private bool checkDisplayZeroCameras()
    {
        foreach (Camera camera in Camera.allCameras)
        {
            if (camera.targetDisplay == 0)
            {
                return true;
            }
        }
        return false;
    }

    private void Exit(bool wasCompleted = false)
    {
        menuCamera.SetActive(true);
        exitButton.enabled = false;
        runButton.enabled = true;
        NextLevelUI.SetActive(false);
        activeCamera.SetActive(false);
        activeCamera = null;

        deviceSettingsPanelController.unsetDeviseSettingsInterface();

        if (wasCompleted)
        {

            var lastCompletedIndex = runLevelLoader.GetLastCompletedLevelIndex();
            if (lastCompletedIndex != null)
            {
                levelShowScrollController.LevelCompleted(lastCompletedIndex.Value);
            }
            LevelInterface lastCompletedLevel = lastLevel;
            if (lastCompletedLevel != null)
            {
                lastRunReport += "######################################\n" + lastCompletedLevel.GetReport();
            }
        }
        Debug.LogWarning(lastRunReport);
        lastReportController.SetText(lastRunReport);
        Destroy(activeLevel);
        activeLevel = null;
        targetGameObjectController.ClearUI();
        deviceSettingsPanelController.ClearUI();
        runLevelLoader.ClearLoadedLevels();
    }

    private void toggleSahders()
    {
        GameObject[] activeCameras =
            (targetPlatform == TargetPlatform.Windows) ?
            windowsPostProcessInterfaces : androidPostProcessInterfaces;
        if (!shadersActive)
        {
            Debug.Log(activeCameras[targetUIDropdown.value].GetComponent<PostProcessInterface>());
            activeCameras[targetUIDropdown.value].GetComponent<PostProcessInterface>().Activate(shaderMenuScrollController.GetShaderList());

            shadersActive = !shadersActive;
        }
        else
        {
            activeCameras[targetUIDropdown.value].GetComponent<PostProcessInterface>().Deactivate();
            shadersActive = !shadersActive;
        }
    }
    private void OpenShaderDB()
    {
        ShaderDB.SetActive(true);
        ShaderDB.GetComponent<SelectShaderDB>().LoadDB(GetComponent<SHADER_DB>());
    }

    private void OpenLevelDB()
    {
        levelDB.SetActive(true);
        levelDB.GetComponent<SelectLevelDB>().LoadDB(GetComponent<LEVEL_DB>());
    }

    private void ToggleJoystickUIFunc()
    {
        JoystickUI.SetActive(!JoystickUI.activeSelf);
    }

    private void ShowLastResults()
    {
        lastReportController.gameObject.SetActive(true);
    }


}
