using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeiaDisplayInit : MonoBehaviour
{
    public Camera head;
    public Camera leftEye;
    public Camera rightEye;
    public int dispalayIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        head.targetDisplay = dispalayIndex;
        leftEye.targetDisplay = dispalayIndex;
        rightEye.targetDisplay = dispalayIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
