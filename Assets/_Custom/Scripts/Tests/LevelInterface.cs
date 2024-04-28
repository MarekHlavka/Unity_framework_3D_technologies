using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class LevelInterface : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private GameObject sceneRootObject;
    [SerializeField] private Vector3 cameraStartPosition;

    // Start is called before the first frame update

    [SerializeField] protected List<GameObject> staticObjects;
    [SerializeField] protected List<GameObject> movableObjects;
    [SerializeField] protected List<GameObject> scalableObjects;

    public void Awake()
    {
        cameraStartPosition = Vector3.zero;
    }

    public virtual Type GetLevelType() { return typeof(LevelInterface); }
    public virtual void Init() { }
    public virtual string GetReport() { 
        return GetReportHeader(typeof(LevelInterface).ToString()) + "Default report\n\n";
    }

    protected string GetReportHeader(string levelType)
    {
        string formatString = "Name:    {0} - ({1})\n" +
                              "Runed:   {2}\n" +
                              "---------------------------------------------\n" +
                              "Results:\n\n";
        return string.Format(formatString, levelName, levelType, DateTime.UtcNow);
    }

    protected void InitLists()
    {
        staticObjects = new List<GameObject>();
        movableObjects = new List<GameObject>();
        scalableObjects = new List<GameObject>();
    }

    // Update is called once per frame
    public void Update()
    {
        //Debug.Log("Update from parent");
    }

    public string GetLevelName()
    {
        return levelName;
    }

    public GameObject GetRootGameObject()
    {
        return sceneRootObject;
    }

    public List<GameObject> GetStaticObjects()
    {
        return staticObjects;
    }
    public List<GameObject> GetMovableObjects()
    {
        return movableObjects;
    }
    public List<GameObject> GetScalableObjects() { return scalableObjects; }
    public Vector3 GetStartPosition() { return cameraStartPosition; }

    

}
