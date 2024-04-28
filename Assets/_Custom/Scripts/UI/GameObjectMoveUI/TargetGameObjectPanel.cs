using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetGameObjectPanel : MonoBehaviour
{
    [SerializeField] protected TMP_Text targetName;
    [SerializeField] protected Button highlightButton;

    [SerializeField] protected GameObject targetGameObject;
    [SerializeField] protected Slider slider;

    protected bool isHighlighted = false;

    protected Color highlightColor = Color.red;

    // Start is called before the first frame update
    protected void Start()
    {
        highlightButton.onClick.AddListener(ToggleHighlight);
    }

    protected void ToggleHighlight()
    {
        if(targetGameObject != null)
        {
            if (!isHighlighted)
            {
                Outline outline = targetGameObject.AddComponent<Outline>();
                outline.UpdateOutline(20.0f, highlightColor);
                outline.enabled = true;
                isHighlighted = true;
            }
            else
            {
               Outline outline = targetGameObject.GetComponent<Outline>();
               if(outline != null )
                {
                    Destroy(outline);
                    isHighlighted = false;
                }
            }
        }
    }

    public void SetGameObject(GameObject target)
    {
        targetGameObject = target;
    }

    public void SetName(string name)
    {
        targetName.text = name;
    }

    public void SetSliderReference(Slider slider)
    {
        this.slider = slider;
    }


}
