using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Toggle selected;
    [SerializeField] private SelectLevelDB dbController;
    private LevelInterface level;

    public void SetName(string name)
    {
        _name.text = name;
    }

    public void SetLevel(LevelInterface level)
    {
        this.level = level;
    }

    public void SetBackgroundColor(Color color)
    {
        GetComponent<Image>().color = color;
    }

    public LevelInterface GetLevel() { return level; }
    public void SetSelectLevelDB(SelectLevelDB dbController)
    {
        this.dbController = dbController;
    }

    public bool GetSelectedStatus() {
        return selected.isOn;
    }
}
