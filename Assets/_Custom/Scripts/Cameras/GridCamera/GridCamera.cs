using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCamera : MonoBehaviour
{
    /// -------------------------------------------
    /// Generating 3x3 Grid camera object
    /// -------------------------------------------


    public const float DefaultSeparation = 0.067f;
    public const float MinSeparation = 0.01f;
    public const float MaxSeparation = 1.0f;
    public const float DefaultConvergence = 3.0f;
    public const float MinConvergence = 0.01f;
    public const float MaxConvergence = 30.0f;

    public float separation = DefaultSeparation;
    public float convergence = DefaultConvergence;

    private static int cameras_count = 9;
    public GameObject part_camera;      // Prefab of one camera which is whole camera contructed from
    public RenderTexture target;        // TODO possible remove
    public GameObject parent_object;    // Parent object from instantiating part camera

    public Material postProcessMat;     // TODO remove with shaders
    public int targetDisplayIndex;      // Index of display to render to

    private GameObject[] cameras = new GameObject[cameras_count];

    float previousSeparation;
    float previousConvergence;

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < cameras_count; i++)
        {
            cameras[i] = Instantiate(part_camera, parent_object.transform);
            cameras[i].transform.localPosition = Vector3.zero;
        }
        Initialze();
        Debug.Log("What the hell");
    }

    // Update is called once per frame
    void Update()
    {
        if (previousSeparation != separation || previousConvergence != convergence)
            UpdatePositions();
        for (int i = 0; i < cameras_count; i++)
        {
            Camera cam = cameras[i].GetComponent<Camera>();
            cam.targetDisplay = targetDisplayIndex;
        }
    }

    void Reset()
    {
        separation = DefaultSeparation;
        convergence = DefaultConvergence;
    }

    void OnValidate()
    {
        // clamp values
        separation = Mathf.Clamp(separation, MinSeparation, MaxSeparation);
        convergence = Mathf.Clamp(convergence, MinConvergence, MaxConvergence);
    }

    // Rect = X, Y, Width, Heigth
    // Create caneras and  modify output rectangles to be coorenct for 3D TV
    public void Initialze() {

        float grid_part = 1.0f / 3.0f;

        for (int i = 0;i < cameras_count;i++)
        {
            int col = i % 3 + 1;
            int row = i / 3;

            Camera camera = cameras[i].GetComponent<Camera>();
            camera.orthographic = false;

            camera.rect = new Rect(
                1.0f - (col * grid_part),
                (row * grid_part),
                grid_part,
                grid_part);
            var aspect = Screen.height == 0 ? 1 : Screen.width / (float)Screen.height;
            camera.aspect = aspect;
            camera.targetDisplay = 1;
        }
        GetComponent<PostProcessInterface>().AddCameras(cameras);
    }

    public void UpdatePositions()
    {

        float part_separation = separation / 4.0f;

        int camera_index = 0;
        int camera_count_border = (int)(Mathf.Floor(cameras_count / 2.0f));
        for (int i = -1 * camera_count_border; i <= camera_count_border; i++)
        {
            if (i != 0)
            {
                cameras[camera_index].transform.localPosition = i * part_separation * Vector3.right;
                var angle = 90.0f - Mathf.Atan2(convergence, i * part_separation) * Mathf.Rad2Deg;
                cameras[camera_index].transform.localRotation = Quaternion.AngleAxis(-angle, Vector3.up);
            }

            camera_index++;
        }

        previousSeparation = separation;
        previousConvergence = convergence;
    }

    public float getMinSeparation()
    {
        return MinSeparation;
    }
    public float getMaxSeparation()
    {
        return MaxSeparation;
    }

    public float getMinConvergence()
    {
        return MinConvergence;
    }
    public float getMaxConvergence()
    {
        return MaxConvergence;
    }
}
