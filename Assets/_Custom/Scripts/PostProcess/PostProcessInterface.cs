using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessInterface : MonoBehaviour
{
    [SerializeField]
    private PostProcessRender[] targetCameras;

    public void Activate(List<Material> materials)
    {
        for(int i = 0; i < targetCameras.Length; i++)
        {
            targetCameras[i].Activate(materials);
        }
        // Activate this Camera type
        transform.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        for (int i = 0; i < targetCameras.Length; i++)
        {
            targetCameras[i].Deactivate();
        }
        // Deactivate this Camera type
        // transform.gameObject.SetActive(false);
    }

    public void AddCameras(GameObject[] cameras)
    {
        targetCameras = new PostProcessRender[cameras.Length];
        for (int i = 0;i < cameras.Length; i++)
        {
            targetCameras[i] = cameras[i].GetComponent<PostProcessRender>();
        }
    }
}
