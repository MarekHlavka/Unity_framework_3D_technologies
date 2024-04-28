using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LastReportController : MonoBehaviour
{
    [SerializeField] private TMP_Text infoText;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button copyToClipboardButton;
    void Start()
    {
        exitButton.onClick.AddListener(Exit);
        copyToClipboardButton.onClick.AddListener(CopyToClipboadr);
    }

    private void Exit()
    {
        transform.gameObject.SetActive(false);
    }

    private void CopyToClipboadr(){
        GUIUtility.systemCopyBuffer = infoText.text;
    }

    public void SetText(string text)
    {
        infoText.text = text;
    }
}
