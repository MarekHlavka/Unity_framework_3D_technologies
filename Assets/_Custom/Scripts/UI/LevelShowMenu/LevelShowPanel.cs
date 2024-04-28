using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelShowPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text levelName;
    [SerializeField] private TMP_Text levelIndex;
    [SerializeField] private Image background;


    public void SetLevelName(string _name)
    {
        levelName.text = _name;
    }

    public void SetLevelIndex(string _index)
    {
        levelIndex.text = _index;
    }

    public void SetBackgroundColor(Color _background)
    {
        background.color = _background;
    }
}
