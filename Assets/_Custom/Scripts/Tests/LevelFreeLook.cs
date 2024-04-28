using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFreeLook : LevelInterface
{
    override public void Init()
    {
        InitLists();
    }

    override public Type GetLevelType()
    {
        return typeof(LevelFreeLook);
    }


    public override string GetReport()
    {
        string header = GetReportHeader(typeof(LevelFreeLook).ToString());
        string text = "Free look level - no data to report...\n";
        return header + text;
    }
}
