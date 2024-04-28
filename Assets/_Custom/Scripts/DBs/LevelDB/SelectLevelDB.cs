using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelDB : MonoBehaviour
{
    private GameObject loadedLevel;
    private List<LevelPanel> levelPanels;
    private int currentLevelIndex;
    [SerializeField] private GameObject panelPrefab;
    [SerializeField] private GameObject targetScrollPanel;
    [SerializeField] private Button loadButton;
    [SerializeField] private RunLevelLoader levelLoader;

    private void Start()
    {
        loadButton.onClick.AddListener(LoadSelectedLevels);
        currentLevelIndex = 0;
    }


    public void SetLoadedLevel(GameObject level)
    {
        loadedLevel = level;
    }
    public GameObject GetLoadedLevel() { return loadedLevel; }

    public void LoadDB(LEVEL_DB db)
    {
        foreach (Transform child in targetScrollPanel.transform)
        {
            Destroy(child.gameObject);
        }
        List<GameObject> levels = db.GetLevels();
        levelPanels = new List<LevelPanel>();
        for (int i = 0; i < levels.Count; i++)
        {
            LevelFreeLook[] lfl_list;
            lfl_list = levels[i].GetComponents<LevelFreeLook>();

            LevelTwoCompare[] ltc_list;
            ltc_list = levels[i].GetComponents<LevelTwoCompare>();;

            LevelCorrectOrder[] lco_list;
            lco_list = levels[i].GetComponents<LevelCorrectOrder>();

            LevelTwoScale[] lts_list;
            lts_list = levels[i].GetComponents<LevelTwoScale>();

            foreach (LevelFreeLook lfl in lfl_list) {
                GameObject newPanel = Instantiate(panelPrefab, targetScrollPanel.transform);
                LevelPanel newLevelpanel = newPanel.GetComponent<LevelPanel>();

                newLevelpanel.SetSelectLevelDB(this);
                newLevelpanel.SetName(lfl.GetLevelName());
                newLevelpanel.SetLevel(lfl);
                // newLevelpanel.SetBackgroundColor(Color.gray);
                levelPanels.Add(newLevelpanel);

            }
            foreach (LevelTwoCompare ltc in ltc_list) {
                GameObject newPanel = Instantiate(panelPrefab, targetScrollPanel.transform);
                LevelPanel newLevelpanel = newPanel.GetComponent<LevelPanel>();

                newLevelpanel.SetSelectLevelDB(this);
                newLevelpanel.SetName(ltc.GetLevelName());
                newLevelpanel.SetLevel(ltc);
                // newLevelpanel.SetBackgroundColor(Color.cyan);
                levelPanels.Add(newLevelpanel);
            }
            foreach (LevelCorrectOrder lco in lco_list) {
                GameObject newPanel = Instantiate(panelPrefab, targetScrollPanel.transform);
                LevelPanel newLevelpanel = newPanel.GetComponent<LevelPanel>();

                newLevelpanel.SetSelectLevelDB(this);
                newLevelpanel.SetName(lco.GetLevelName());
                newLevelpanel.SetLevel(lco);
                // newLevelpanel.SetBackgroundColor(Color.red);
                levelPanels.Add(newLevelpanel);
            }
            foreach (LevelTwoScale lts in lts_list)
            {
                GameObject newPanel = Instantiate(panelPrefab, targetScrollPanel.transform);
                LevelPanel newLevelpanel = newPanel.GetComponent<LevelPanel>();

                newLevelpanel.SetSelectLevelDB(this);
                newLevelpanel.SetName(lts.GetLevelName());
                newLevelpanel.SetLevel(lts);
                // newLevelpanel.SetBackgroundColor(Color.magenta);
                levelPanels.Add(newLevelpanel);
            }


        }
    }


    private void LoadSelectedLevels()
    {
        levelLoader.AddLevels(levelPanels);
        transform.gameObject.SetActive(false);
    }

}
