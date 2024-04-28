using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Class for working with shader data when running framework
public class ShaderDBItem : MonoBehaviour
{
    public string shaderName;
    [TextArea] public string shaderDescription;
    public Shader shader;
    public bool isSelected;

    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Toggle _isActive;

    private int index = 0;

    public void setGUI()
    {
        _name.text = shaderName;
        _description.text = shaderDescription;
        _isActive.isOn = isSelected;
        _isActive.onValueChanged.AddListener(delegate
        {
            isSelected = _isActive.isOn;
        });
    }

    public void setIndex(int i)
    {
        index = i;
    }
    public int getIndex()
    {
        return index;
    }

}


// Class for working with shader data when in Editor
// For laoding shaders etc.
[System.Serializable]
public class ShaderDBItemEditor{

    public string shaderName;
    [TextArea] public string shaderDescription;
    public Shader shader;
    public bool isSelected;

    public ShaderDBItemEditor(string shaderName, string shaderDescription, Shader shader)
    {
        this.shaderName = shaderName;
        this.shaderDescription = shaderDescription;
        this.shader = shader;
        this.isSelected = false;
    }

    
}
