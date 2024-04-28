using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidePlatformSwitchMenuButton : MonoBehaviour
{

    [SerializeField] private GameObject targetUI;
    [SerializeField] private GameObject secondaryUI;
    [SerializeField] private Image image;
    [SerializeField] private bool isOut;
    [SerializeField] private Animations animations;
    [SerializeField] private float animationSpeed;

    private float verticalMovement;
    private float secondaryVerticalMovement;
    private bool isMoving;
    private float elapsedMovementTime;
    private Vector3 hidePosition;
    private Vector3 outPosition;
    private Vector3 secondaryHidePosition;
    private Vector3 secondaryOutPosition;


    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ToggleUI);
        verticalMovement = targetUI.GetComponent<RectTransform>().rect.height *
            targetUI.transform.parent.gameObject.GetComponent<RectTransform>().localScale.y;
        secondaryVerticalMovement = targetUI.GetComponent<RectTransform>().rect.height *
            secondaryUI.transform.parent.gameObject.GetComponent<RectTransform>().localScale.y;

        hidePosition = targetUI.transform.position - (isOut ? Vector3.down * verticalMovement : Vector3.zero);
        outPosition = targetUI.transform.position - (isOut ? Vector3.zero : Vector3.up * verticalMovement);

        secondaryHidePosition = secondaryUI.transform.position - (isOut ? Vector3.up * verticalMovement : Vector3.zero);
        secondaryOutPosition = secondaryUI.transform.position - (isOut ? Vector3.zero : Vector3.down * verticalMovement);

        isMoving = false;
        animationSpeed = 0.8f;
        elapsedMovementTime = 0.0f;

    }

    private void Update()
    {
        GetComponent<Button>().interactable = !isMoving;
        if (isMoving)
        {   
            if (elapsedMovementTime > 1.0f)
            {
                isOut = !isOut;
                isMoving = false;
                return;
            }
            if (isOut)
            {
                targetUI.transform.position = outPosition + Vector3.up * verticalMovement * animations.GetWaveCurveValue(elapsedMovementTime);
                secondaryUI.transform.position = secondaryOutPosition + Vector3.down * secondaryVerticalMovement * animations.GetWaveCurveValue(elapsedMovementTime);
            }
            if(!isOut)
            {
                targetUI.transform.position = hidePosition + Vector3.down * verticalMovement * animations.GetWaveCurveValue(elapsedMovementTime);
                secondaryUI.transform.position = secondaryHidePosition + Vector3.up * secondaryVerticalMovement * animations.GetWaveCurveValue(elapsedMovementTime);
            }
            elapsedMovementTime += Time.deltaTime * animationSpeed;
            image.transform.eulerAngles = new Vector3(0, 0, animations.GetWaveCurveValue(elapsedMovementTime)*180 + (isOut ? 0 : 180));
        }
    }

    private void ToggleUI()
    {
        isMoving = true;
        elapsedMovementTime = 0.0f;
    }
}
