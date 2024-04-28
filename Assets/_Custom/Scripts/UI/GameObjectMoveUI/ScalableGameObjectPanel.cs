using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalableGameObjectPanel : TargetGameObjectPanel
{
    [SerializeField] private Button scaleUpButton;
    [SerializeField] private Button scaleDownButton;
    [SerializeField] private float speed = 0.5f;

    // Updating Z coordinate

    new void Start()
    {
        base.Start();

    }

    private void Update()
    {
        speed = slider.value;
        if (scaleUpButton.GetComponent<MyButton>().buttonPressed)
        {
            targetGameObject.transform.localScale += speed * Vector3.one;
        }
        if (scaleDownButton.GetComponent<MyButton>().buttonPressed)
        {
            targetGameObject.transform.localScale -= speed * Vector3.one;
        }
    }

}
