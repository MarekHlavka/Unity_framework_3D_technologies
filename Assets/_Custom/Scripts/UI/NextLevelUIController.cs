using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text currentLevel;
    [SerializeField] private TMP_Text nextLevel;
    [SerializeField] private TMP_Text nextButton;

    public void updateTexts(string current, string next)
    {
        currentLevel.text = current;
        nextLevel.text = next;
    }

    public void SetButtonText(string newText){
        nextButton.text = newText;
    }

}
