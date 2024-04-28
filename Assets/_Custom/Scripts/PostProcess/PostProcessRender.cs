using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PostProcessRender : MonoBehaviour
{

    // TODO probably remove
    public Shader[] postProcessShaders = null;

    private List<Material> postProcessMaterials = null;

    private RenderTexture prev = null;
    //private RenderTexture tmp_dst = null;

    private List<RenderTexture> tmp_textures = new List<RenderTexture>();

    private bool init_textures = false;
    private bool isActive = false;
    
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // Only active form currently rendering cameras
        if (isActive)
        {
            if (init_textures)
            {
                for (int i = 0; i < postProcessMaterials.Count; i++)
                {
                    tmp_textures.Add(new RenderTexture(source));
                }
                init_textures = false;
            }

            // Graphics.Blit(source, destination, postPrecessMaterial);
            if (postProcessMaterials != null)
            {
                prev = source;
                for (int i = 0; i < postProcessMaterials.Count; i++)
                {
                    Graphics.Blit(prev, tmp_textures[i], postProcessMaterials[i]);
                    prev = tmp_textures[i];

                }
                Graphics.Blit(prev, destination);

            }
            else
            {
                Graphics.Blit(source, destination);
            }
        }
        else
        {
            Graphics.Blit(source, destination);
        }


    }

    public void Activate(List<Material> materials) 
    {
        postProcessMaterials = new List<Material>(materials);

        init_textures = true;
        isActive = true;
    }
    public void Deactivate()
    {
        isActive = false;
        postProcessMaterials.Clear();
    }

}
