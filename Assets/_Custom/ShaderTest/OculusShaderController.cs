using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusShaderController : MonoBehaviour
{

    public HoloShader _camera;
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        _camera.material = material;
    }

}
