using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleShaderPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Button _up;
    [SerializeField] private Button _down;

    private ShaderDBItem _item;
    private ShaderMenuScrollController scrollControler;

    private void Start()
    {
        _toggle.onValueChanged.AddListener(delegate { 
            _item.isSelected = _toggle.isOn;
        });
    }

    public void setName(string newName)
    {
        _name.text = newName;
    }

    public void setItem(ShaderDBItem src_item)
    {
        _item = src_item;
    }

    public ShaderDBItem getItem()
    {
        return _item;
    }

    public void setShaderController(ShaderMenuScrollController controller)
    {
        scrollControler = controller;
        _up.onClick.AddListener(delegate { scrollControler.moveIndexUp(_item.getIndex()); });
        _down.onClick.AddListener(delegate { scrollControler.moveIndexDown(_item.getIndex()); });
        
    }

    public ShaderMenuScrollController getScrollControler()
    {
        return scrollControler;
    }
}
