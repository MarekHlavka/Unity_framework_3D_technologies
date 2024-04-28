using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameControler : MonoBehaviour
{
    [SerializeField]
    private TargetPlatform targetPlatform;

    public void SetPlatform(TargetPlatform platfrom)
    {
        targetPlatform = platfrom;
    }

    public TargetPlatform GetPlatform()
    {
        return targetPlatform;
    }

    

}
