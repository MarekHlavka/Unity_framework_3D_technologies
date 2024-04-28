using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StereCameraController : MonoBehaviour
{

    public GameObject leftCamera;
    public GameObject rightCamera;
    public int targetDisplayIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Camera leftCam = leftCamera.GetComponent<Camera>();
        Camera rightCam = rightCamera.GetComponent<Camera>();
        leftCam.targetDisplay = targetDisplayIndex;
        rightCam.targetDisplay = targetDisplayIndex;
    }
}
