using LookingGlass;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LKG_Interface : MonoBehaviour
{
    [SerializeField] private float near_plane = 1.0f;
    [SerializeField] private float far_plane = 10.0f;
    [SerializeField] private float size = 50.0f;

    [SerializeField] private HologramCamera LKGCamera;

    public void setNearPlane(float near_plane)
    {
        this.near_plane = near_plane;
        LKGCamera.CameraProperties.NearClipFactor = near_plane;
        
    }

    public void setFarPlane(float far_plane)
    {
        this .far_plane = far_plane;
        LKGCamera.CameraProperties.FarClipFactor = far_plane;
    }
}
