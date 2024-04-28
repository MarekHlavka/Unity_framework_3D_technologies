using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAllUI : MonoBehaviour
{

    [SerializeField] private GameObject targetUI;
    [SerializeField] private GameObject onImage;
    [SerializeField] private GameObject offImage;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ToggleUI);
        targetUI.SetActive(true);
        onImage.SetActive(true);
        offImage.SetActive(false);
    }

    private void ToggleUI()
    {
        targetUI.SetActive(!targetUI.activeSelf);
        onImage.SetActive(!onImage.activeSelf);
        offImage.SetActive(!onImage.activeSelf);
    }
}
