using LookingGlass;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingGlassCamera : MonoBehaviour
{

    public int lkg_index = 0;
    public float near_plane = 1.0f;
    public float far_plane = 10.0f;
    public float size = 50.0f;


    public GameObject lkg_cameras;
    // Start is called before the first frame update
    void Start()
    {
        HologramCamera holocam = lkg_cameras.GetComponent<HologramCamera>();
        holocam.CameraProperties.NearClipFactor = near_plane;
        holocam.CameraProperties.FarClipFactor = far_plane;
        holocam.CameraProperties.Size = size;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
