using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AdroidUIController : MonoBehaviour
{
    public Button left;
    public Button right;
    public GameObject movingObject;

    // Start is called before the first frame update
    void Start()
    {
        left.onClick.AddListener(MoveLeft);
        right.onClick.AddListener(MoveRight);
    }

    private void MoveLeft()
    {
        movingObject.transform.localPosition += Vector3.right * 0.3f;
    }

    private void MoveRight()
    {
        movingObject.transform.localPosition -= Vector3.right * 0.3f;
    }
}
