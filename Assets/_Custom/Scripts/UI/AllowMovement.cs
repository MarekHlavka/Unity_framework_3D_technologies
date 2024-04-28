using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllowMovement : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Player player;

    // Update is called once per frame
    void Awake()
    {
        toggle.onValueChanged.AddListener(player.setAllowMovement);
    }

    public void SetCheckmark(bool checkmark)
    {
        toggle.isOn = checkmark;
    }
}
