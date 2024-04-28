using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectShaderDB : MonoBehaviour
{
    // -----------------------------------------
    // Script for controlling Load shaders window
    // loading shaders from pseudo-database
    // -----------------------------------------

    [SerializeField] private GameObject itemPrefab;         // Prefab panel to visualize all loaded shaders
    [SerializeField] private GameObject targetScrollPanel;  // Target panel to instantiate itemPrefabs
    [SerializeField] private Button loadShadersButton;      // Button for loading shaders from DB to menu and closing Load window
    [SerializeField] private ShaderMenuScrollController shaderMenuScroll;   // Controller of shader menu
    
    private List<ShaderDBItem> shaders = new List<ShaderDBItem>();

    private void Start()
    {
        loadShadersButton.onClick.AddListener(AddShadersToMenu);
    }

    // Loading shders form pseudo-DB to load window
    public void LoadDB(SHADER_DB db) 
    {
        shaders.Clear();
        foreach (Transform child in targetScrollPanel.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < db.shadersList.Count; i++)
        {
            GameObject newItem = Instantiate(itemPrefab, targetScrollPanel.transform);
            ShaderDBItem newShaderDB = newItem.GetComponent<ShaderDBItem>();
            newShaderDB.shaderName = db.shadersList[i].shaderName;
            newShaderDB.shaderDescription = db.shadersList[i].shaderDescription;
            newShaderDB.shader = db.shadersList[i].shader;
            newShaderDB.isSelected = false;
            newShaderDB.setGUI();
            shaders.Add(newShaderDB);
            
        }
    }

    // Load shaders to shader menu
    private void AddShadersToMenu()
    {
        shaderMenuScroll.AddShaders(shaders);
        transform.gameObject.SetActive(false);
    }
}
