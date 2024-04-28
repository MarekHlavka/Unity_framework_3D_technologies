using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoCompare : LevelWithMoveDirection
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private GameObject movableObject;


    override public void Init()
    {
        InitLists();
        staticObjects.Add(targetObject);
        movableObjects.Add(movableObject);
    }

    override public Type GetLevelType()
    {
        return typeof(LevelTwoCompare);
    }

    public override string GetReport()
    {
        string header = GetReportHeader(typeof(LevelCorrectOrder).ToString());
        float targetObjDst = PlayerFromgameObjectDistance(targetObject);
        float movableObjDst = PlayerFromgameObjectDistance(movableObject);

        string text = "{0,10}   Target distance\n" +
                      "{1,10}   Movable object distance \n" +
                      "{2,10}   Difference\n";
        return header + string.Format(text, targetObjDst, movableObjDst, Math.Abs(targetObjDst - movableObjDst));
    }

}
