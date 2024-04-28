using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoScale : LevelInterface
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private GameObject scalableObject;


    override public void Init()
    {
        InitLists();
        staticObjects.Add(targetObject);
        scalableObjects.Add(scalableObject);
    }

    override public Type GetLevelType()
    {
        return typeof(LevelTwoScale);
    }

    public override string GetReport()
    {
        string header = GetReportHeader(typeof(LevelTwoScale).ToString());
        string text =   "{0,10}   Target local scale\n" +
                        "{1,10}   Scalable object local scale \n" +
                        "{2,10}   Difference\n";
        float target = targetObject.transform.localScale.x;
        float scalable = scalableObject.transform.localScale.x;
        return header + string.Format(text, target, scalable, Math.Abs(Math.Abs(scalable) - Math.Abs(target)));
    }
}
