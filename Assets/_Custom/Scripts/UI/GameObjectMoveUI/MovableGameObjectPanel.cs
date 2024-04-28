using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovableGameObjectPanel : TargetGameObjectPanel
{
    [SerializeField] private Button moveTowardsButton;
    [SerializeField] private Button moveAwayButton;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] protected Vector3 moveDirection;

    // Updating Z coordinate

    private bool moveTowards;
    private bool moveAway;

    new void Start()
    {
        base.Start();
    }

    private void Update()
    {
        speed = slider.value;
        if (moveTowardsButton.GetComponent<MyButton>().buttonPressed)
        {
            targetGameObject.transform.position -= speed * moveDirection;
        }
        if (moveAwayButton.GetComponent<MyButton>().buttonPressed)
        {
            targetGameObject.transform.position += speed * moveDirection;
        }
    }


    public void SetMoveDirection(Vector3 inVector)
    {
        moveDirection = inVector;
    }
}
