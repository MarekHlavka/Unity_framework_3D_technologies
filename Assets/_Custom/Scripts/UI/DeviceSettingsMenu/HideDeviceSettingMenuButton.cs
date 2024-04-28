using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideDeviceSettingMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject targetUI;
    [SerializeField] private Canvas targetCanvas;
    [SerializeField] private Image image;
    [SerializeField] private bool isOut;
    [SerializeField] private Animations animations;
    [SerializeField] private float animationSpeed;

    private float horizontalMovement;
    private bool isMoving;
    private float elapsedMovementTime;
    private Vector3 hidePosition;
    private Vector3 outPosition;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ToggleUI);
        horizontalMovement = targetUI.GetComponent<RectTransform>().rect.width *
            targetUI.transform.parent.gameObject.GetComponent<RectTransform>().localScale.x;
        hidePosition = targetUI.transform.position - (isOut ? Vector3.left * horizontalMovement : Vector3.zero);
        outPosition = targetUI.transform.position - (isOut ? Vector3.zero : Vector3.right * horizontalMovement);
        isMoving = false;
        animationSpeed = 0.8f;
        elapsedMovementTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Button>().interactable = !isMoving;
        if(isMoving)
        {
            if(elapsedMovementTime > 1.0f)
            {
                isOut = !isOut;
                isMoving = false;
                if (!isOut)
                {
                    targetCanvas.sortingOrder = 0;
                }
                return;
            }
            if (isOut)
            {
                targetUI.transform.position = outPosition + Vector3.right * horizontalMovement * animations.GetWaveCurveValue(elapsedMovementTime);
            }
            if(!isOut)
            {
                targetUI.transform.position = hidePosition + Vector3.left * horizontalMovement * animations.GetWaveCurveValue(elapsedMovementTime);
            }
            elapsedMovementTime += Time.deltaTime * animationSpeed;
            /// image.transform.eulerAngles = new Vector3(0, 0, animations.GetWaveCurveValue(elapsedMovementTime)*180 + (isOut ? 0 : 180));
        }
    }

    private void ToggleUI()
    {
        isMoving = true;
        elapsedMovementTime = 0.0f;
        if (targetCanvas.sortingOrder == 0)
        {
            targetCanvas.sortingOrder = 1;
        }
    }
}
