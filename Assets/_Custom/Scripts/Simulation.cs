using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Simulation : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log ("displays connected: " + Display.displays.Length);
        text1.text = Display.displays.Length.ToString();
            // Display.displays[0] is the primary, default display and is always ON, so start at index 1.
            // Check if additional displays are available and activate each.

        // TODO Aktivovat displeje v buildu

        for (int i = 0; i < Display.displays.Length; i++)
            {
                //Display.displays[i].Activate();
                text2.text += i + ": " + Display.displays[i].systemWidth.ToString()+ "\n";
            }
    }

    // Update is called once per frame
    void Update()
    {
        
        // TODO make function for view all cameras as tiles one one monitor

    }
}
