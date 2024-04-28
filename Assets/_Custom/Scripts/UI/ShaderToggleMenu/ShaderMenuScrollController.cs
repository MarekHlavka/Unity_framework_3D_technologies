using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderMenuScrollController : MonoBehaviour
{
    [SerializeField] private ToggleShaderPanel instantiatePrefab;
    [SerializeField] private GameObject parentObject;

    private List<ShaderDBItem> selectedItems = new List<ShaderDBItem>();

    public void AddShaders(List<ShaderDBItem> items)
    {
        selectedItems.Clear();
        foreach (Transform child in parentObject.transform)
        {
            Destroy(child.gameObject);
        }
        int local_index = 0;
        for (int i = 0; i < items.Count; i++)
        {
            
            if (items[i].isSelected)
            {
                
                selectedItems.Add(items[i]);
                ToggleShaderPanel newPrefab = Instantiate(instantiatePrefab, parentObject.transform);
                newPrefab.setName(items[i].shaderName);
                newPrefab.setItem(items[i]);
                newPrefab.setShaderController(transform.gameObject.GetComponent<ShaderMenuScrollController>());
                items[i].setIndex(local_index);
                local_index++;
                
                
            }
        }
    }

    public void moveIndexUp(int src_index)
    {
        Debug.Log("Move index up " + src_index.ToString());
        if (src_index > 0)
        {
            ShaderDBItem tmp = selectedItems[src_index - 1];
            selectedItems[src_index - 1] = selectedItems[src_index];
            selectedItems[src_index] = tmp;
        }
        RedrawShaders();
    }
    public void moveIndexDown(int src_index)
    {
        Debug.Log("Move index down " + src_index.ToString());
        if (src_index < selectedItems.Count - 1)
        {
            ShaderDBItem tmp = selectedItems[src_index + 1];
            selectedItems[src_index + 1] = selectedItems[src_index];
            selectedItems[src_index] = tmp;
        }
        RedrawShaders();
    }

    public void RedrawShaders()
    {
        foreach (Transform child in parentObject.transform)
        {
            Destroy(child.gameObject);
        }
        int local_index = 0;
        for (int i = 0;i < selectedItems.Count;i++)
        {
            ToggleShaderPanel newPrefab = Instantiate(instantiatePrefab, parentObject.transform);
            newPrefab.setName(selectedItems[i].shaderName);
            newPrefab.setItem(selectedItems[i]);
            newPrefab.setShaderController(transform.gameObject.GetComponent<ShaderMenuScrollController>());
            selectedItems[i].setIndex(local_index);
            local_index++;
        }
    }

    public List<Material> GetShaderList()
    {
        List<Material> postProcessMaterials = new List<Material>();
        for (int i = 0; i < selectedItems.Count; i++)
        {
            if (selectedItems[i].isSelected)
            {
                postProcessMaterials.Add(new Material(selectedItems[i].shader));
            }
        }
        return postProcessMaterials;
    }
}
