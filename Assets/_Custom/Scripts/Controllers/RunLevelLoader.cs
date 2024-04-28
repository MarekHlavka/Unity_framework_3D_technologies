using JetBrains.Annotations;
using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunLevelLoader : MonoBehaviour
{

    [SerializeField] private List<LevelInterface> loadedLevels;
    [SerializeField] private LevelShowScrollController levelShowScrollController;
    private int currentLevelIndex;
    private string currentLevelName;
    private string nextLevelName;

    // Start is called before the first frame update
    void Start()
    {
        loadedLevels = new List<LevelInterface>();
        currentLevelIndex = 0;
    }

    public void AddLevels(List<LevelPanel> levelPanels)
    {
        loadedLevels.Clear();
        foreach (LevelPanel levelPanel in levelPanels)
        {
            if (levelPanel.GetSelectedStatus())
            {
                loadedLevels.Add(levelPanel.GetLevel());
            }
        }
        currentLevelIndex = 0;
        transform.gameObject.SetActive(false);

        foreach (LevelInterface levelInterface in loadedLevels)
        {
            Debug.Log(levelInterface.ToString());
        }

        levelShowScrollController.AddShowLevels(loadedLevels);
    }

    public (LevelInterface, string, string) GetNextLoadedLevel()
    {
        if (currentLevelIndex < loadedLevels.Count)
        {
            Debug.Log(loadedLevels[currentLevelIndex].GetType());

            currentLevelName = loadedLevels[currentLevelIndex].GetLevelName();
            nextLevelName = currentLevelIndex + 1 < loadedLevels.Count ? loadedLevels[currentLevelIndex + 1].GetLevelName() : null;

            return (loadedLevels[currentLevelIndex++], currentLevelName, nextLevelName);
        }
        else
        {
            return (null, null, null);
        }
    }

    public int? GetLastCompletedLevelIndex()
    {
        return currentLevelIndex > 0 ? currentLevelIndex - 1 : null;
    }



    public void ClearLoadedLevels()
    {
        loadedLevels.Clear();
    }

}

/// MAKE HERE LOADING / INSTANTIATING AND DESTROING CURRENT LEVELS