using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoUIController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject targetUI;
    [SerializeField] private GameObject onImage;
    [SerializeField] private GameObject offImage;
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text text;

    void Start()
    {
        
        button.onClick.AddListener(ToggleUI);
        targetUI.SetActive(false);
        onImage.SetActive(true);
        offImage.SetActive(false);

        text.text = GetInfoString();
    }

    private void ToggleUI()
    {
        targetUI.SetActive(!targetUI.activeSelf);
        onImage.SetActive(!onImage.activeSelf);
        offImage.SetActive(!onImage.activeSelf);
    }

    private string GetInfoString()
    {
        string infoText = @"
# Framework for testing 3D technologies

###############################################################
## Description
            This is framework for experimenting with 3D technologies, created in Unity3D. Main function is to unergo tests while wathing scene with some 3D technologies. Tests consist of comparising position, order and scale with different object, while scene surroundigs are trying to decieve your reality perseption.

            Currently distributed as project in Unity3D.

###############################################################
## Currently supported technologies
            - classic 2D picture
            - Oculus Rift
            - 3D TV (Stereo, and 3x3 grid picture)
            - Looking Glass display
            - LumePad 2 tablet

###############################################################
## How to use framework

            1. **Run framework on selcted platform**
                Once loaded, main menu is presented. In here there are several options what to do:

                - Load shaders - Shaders cen be loaded from inner pseudodatabase. These sahders can be used to modify rendered output of cameras.
                - Load levels - Here can be loaded tests that will be performed is following testing sequence (after button `Run` is pressed).
                - Select target 3D technologie from dropdown menu.
                - Hide all UI.
                - Show help text (copy of this).
                - Show conntroll joystick (only have any usage in Free look tests).
                - Show log from last test sequence.

            2. **Load tests**
                With corresponding button load test that will be uset in next test sequence.

            3. **[OPTIONAL] Load shaders**
                Load shaders to optionally modify renderred output.

            4. **Select target 3D technology**

            5. **Run test sequnece**
                Only can be done if any test had been loaded to current test sequence.

            6. **Complete tests**
                In this moment, new 4 parts of user interace will be meaningful. These are popable panel at window sides, and their purpose is:

                1. *Level overview* - Here all loaded levels can be seen. Additionally, you cen see all tests that was succefully completed with green background.
                2. *Shader overview* - Here is shader pipeline. Here can be turned on/off all shaders at once, or turn them on/off one by one. Also, order of applying shaders can be changed here.
                3. *Device settings* - In this part if UI, parameters of current rendering camera can be modified. Parameterc like distance between cameras in stereorendering or near plane of Looking Glass camera.
                4. *Test controlls* - This is main part of testing. Here can be changed position or scale of testing objects in scene. Parameters of these object are taken as input for test evaluation.

###############################################################
## Test type explanation

            - **LevelFreeLook** - This is test with only review purpose. There is no mtric for testing. It is also only test, where movement is possible. Only for looking at test enviroment.
            - **LevelTwoCompare** - This test is comparison of two object. One movable and one to compare it with. In the UI, only one can be moved with. Target is to have both object in the same distance from camera.
            - **LevelTwoScale** - This test is elmost identcal with *LevelTwoScale*, but changing metric is scale and not position.
            - **LevelCorrectOrder** - Again test to copmare distance. This time there is `1..X` object and target is to order them correctly. Corrent order is indicated with panel index (top panel in UI is representing object that should be closest to camera)

###############################################################
 ## How to add custom shader

            On `GameControler` object is component `SHADER_DB` - there is form to add new shader. Firstly, of course, there has to be one created inside of Unity editor.

###############################################################
## How to add custom camera/3D technology

            Create wrapping GameObject thats wraps all needed GameObject off that technology and add reference to list of cameras on `GameController` GameObject to correct target platform (or both if possible and wanted). Also need to add `PostProcessInterface` script to wrapping object and `PostPorcessRedner` script do all cameras in inside hiearchy.

###############################################################
## How to add new test

            Firstly create GameObject that contains scene object. On this wrapping GameObject add as meny test scripts as wanted (*LevelTwoCompare, LevelTwoScale, ...*). After that on `GameControler` object is component `LEVEL_DB` where can be wrapping object added simple directly into list.

###############################################################
## How to add new test type

            This is most complicated addition. New test have to be inherited (directly or indirectly) from `LevelInterface`. After that from code try to follow steps of already existed test types. Possibly hove to create custom panel for new test object (apart from movable and scalable). More detailed description is possible in future **TODO**.

###############################################################
## How to switch target platform

            Platform switch is done with Unity paltform switch in build menu. Additionally there is custom UI on `GameController` object that switches paremeters needed by framework. Have to be controlled and checked against Unity build target by User.

###############################################################
## Third party assets

            - [Looking Glass Unity Plugin](https://lookingglassfactory.com/software/looking-glass-unity-plugin)
            - [Leia Unity v2.2.0](https://www.leiainc.com/developer-resources)
            - [Oculus Integration](https://assetstore.unity.com/packages/tools/integration/oculus-integration-deprecated-82022)
            - [Quick outline](https://assetstore.unity.com/packages/tools/particles-effects/quick-outline-115488)
            - [Toon Environments - World Creator Pack Lite](https://assetstore.unity.com/packages/3d/environments/landscapes/toon-environments-world-creator-pack-lite-264325)
            - [Low Poly Vegetation Kit Lite](https://assetstore.unity.com/packages/3d/environments/low-poly-vegetation-kit-lite-176906)

###############################################################
## Author
            *Marek Hlávka (xhlavk09@stud.fit.vutbr.cz)*
            *Created as Master's thesis project*

            Faculty of information technology BUT

            Version 1.0
            ";

        return infoText;
    }
}
