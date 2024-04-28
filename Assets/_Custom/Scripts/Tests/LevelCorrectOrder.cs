using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class LevelCorrectOrder : LevelWithMoveDirection
{
    //[SerializeField] private List<GameObject> targetObjects;
    [SerializeField] private List<GameObject> orderedObjects = new List<GameObject>();

    // Start is called before the first frame update
    override public void Init()
    {
        InitLists();
        foreach (GameObject obj in orderedObjects)
        {
            movableObjects.Add(obj);
        }
    }
    override public Type GetLevelType()
    {
        return typeof(LevelCorrectOrder);
    }

    private List<GameObject> GetOrderOfTargetGameObjects()
    {
        float minCheckedDst = 0.0f;
        List<GameObject> playerOrderedGameObjects = new List<GameObject>();
        while (playerOrderedGameObjects.Count < orderedObjects.Count) {

            int newMinIndex = -1;
            float minDst = float.MaxValue;

            foreach (GameObject obj in orderedObjects)
            {
                float currentGOdistance = PlayerFromgameObjectDistance(obj);
                if (currentGOdistance > minCheckedDst)
                {
                    if (currentGOdistance < minDst)
                    {
                        minDst = currentGOdistance;
                        newMinIndex = orderedObjects.IndexOf(obj);
                    }
                }
                {
                    
                }
            }
            minCheckedDst = minDst;
            playerOrderedGameObjects.Add(orderedObjects[newMinIndex]);

        }

        return playerOrderedGameObjects;
    }

    private string GetOrderedGOString(List<GameObject> objs, string type)
    {
        string text = type + " (from MIN distance): ";
        foreach (GameObject obj in objs)
        {
            text += obj.name + "   ";
        }
        return text;
    }

    public override string GetReport()
    {
        string header = GetReportHeader(typeof(LevelCorrectOrder).ToString());
        string targetOrder = GetOrderedGOString(orderedObjects, "Targeted order") + "\n";
        string playerOrder = GetOrderedGOString(GetOrderOfTargetGameObjects(), "Player order") + "\n";

        return header + targetOrder + playerOrder;
    }
}
