using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelShowScrollController : MonoBehaviour
{
    [SerializeField] private LevelShowPanel instantiatePrefab;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color completedColor;

    private List<LevelShowPanel> panelList;

    // Start is called before the first frame update
    void Start()
    {
        panelList = new List<LevelShowPanel>();
    }

    public void AddShowLevels(List<LevelInterface> levels)
    {
        panelList.Clear();
        foreach (Transform child in parentObject.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < levels.Count; i++)
        {
            LevelShowPanel newLevelPanel = Instantiate(instantiatePrefab, parentObject.transform);
            newLevelPanel.SetLevelName(levels[i].GetLevelName());
            newLevelPanel.SetLevelIndex(i.ToString());
            newLevelPanel.SetBackgroundColor(defaultColor);
            panelList.Add(newLevelPanel);

            
        }
    }

    public void LevelCompleted(int index)
    {
        Debug.Log(index);
        panelList[index].SetBackgroundColor(completedColor);
    }

    public void ResetColors()
    {
        foreach(LevelShowPanel panel in panelList)
        {
            panel.SetBackgroundColor(defaultColor);
        }
    }
}
