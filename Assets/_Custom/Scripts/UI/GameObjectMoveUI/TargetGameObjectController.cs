using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetGameObjectController : MonoBehaviour
{
    [SerializeField] private MovableGameObjectPanel movablePrefab;
    [SerializeField] private TargetGameObjectPanel staticPrefab;
    [SerializeField] private ScalableGameObjectPanel scalablePrefab;
    
    [SerializeField] private GameObject parentObject;
    [SerializeField] private Slider slider;

    private List<TargetGameObjectPanel> targetPanels;


    // Start is called before the first frame update
    void Start()
    {
        targetPanels = new List<TargetGameObjectPanel>();
        slider.minValue = 0.01f;
        slider.maxValue = 0.5f;
        slider.value = 0.2f;
    }

    private void AddMovebleObject(GameObject go, Vector3 moveVector)
    {
        MovableGameObjectPanel panel = Instantiate(movablePrefab, parentObject.transform);
        panel.SetGameObject(go);
        panel.SetName(go.name);
        panel.SetMoveDirection(moveVector);
        panel.SetSliderReference(slider);

        /// ADD position variation
        float variation = Random.Range(0.5f, 1.5f);
        go.transform.position += moveVector * variation;

        targetPanels.Add(panel);
    }
    private void AddScalableObject(GameObject go){
        ScalableGameObjectPanel panel = Instantiate(scalablePrefab, parentObject.transform);
        panel.SetGameObject(go);
        panel.SetName(go.name);
        panel.SetSliderReference(slider);

        /// ADD scale variation
        float variation = Random.Range(0.5f, 1.5f);
        go.transform.localScale *= variation;

        targetPanels.Add(panel);

    }
    private void AddStaticObject(GameObject go)
    {
        TargetGameObjectPanel panel = Instantiate (staticPrefab, parentObject.transform);
        panel.SetGameObject(go);
        panel.SetName(go.name);
        panel.SetSliderReference(slider);
        targetPanels.Add(panel);
    }

    public void ClearUI()
    {
        foreach (TargetGameObjectPanel panel in targetPanels)
        {
            Destroy(panel.gameObject);
        }

        targetPanels.Clear();
    }

    // Load Level to TargetGameObject User Interface
    public void LoadLevel(LevelInterface level)
    {
        

        ClearUI();

        level.Init();

        foreach (GameObject staticGameObject in level.GetStaticObjects())
        {
            AddStaticObject(staticGameObject);
        }

        foreach (GameObject movableGameObject in level.GetMovableObjects())
        {
            AddMovebleObject(movableGameObject, level.GetComponent<LevelWithMoveDirection>().GetMoveVector());
        }

        foreach (GameObject scalableGameObject in level.GetScalableObjects())
        {
            AddScalableObject(scalableGameObject);
        }
    }
}
