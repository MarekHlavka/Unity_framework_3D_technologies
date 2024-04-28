using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplaySwitch : MonoBehaviour
{
    public MyButton on;
    public MyButton off;
    public TextMeshProUGUI text;
    public bool isPressed;

    // Update is called once per frame
    void Update()
    {
        if (on.buttonPressed)
        {
            isPressed = true;
        }
        if (off.buttonPressed)
        {
            isPressed = false;
        }
    }
}
