using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float tiltSpeed = 0.5f;


    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference lookAction;
    [SerializeField] private InputActionReference verticalAction;

    private bool movementAllowed;
    // Start is called before the first frame update
    void Start()
    {
        inputActionAsset.FindActionMap("Player").Enable();
        movementAllowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementAllowed)
        {
            Vector2 moveVector = moveAction.action.ReadValue<Vector2>();
            Vector2 lookVector = lookAction.action.ReadValue<Vector2>();
            HandleInput(moveVector, lookVector, verticalAction.action.ReadValue<Vector2>().y);
        }
    }

    private void HandleInput(Vector2 moveVector, Vector2 lookVector, float verticalMovement) {
        Vector3 movement = Vector3.zero;
        Vector3 tilt = Vector3.zero;
        //Vector3 position = this.transform.position;

        // --------------------- Keyboard movement ---------------------
        // position
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement += Vector3.down;
        }

        // direction
        if (Input.GetKey(KeyCode.W))
        {
            tilt += Vector3.left * 0.2f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            tilt += Vector3.right * 0.2f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            tilt += Vector3.up * 0.2f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            tilt += Vector3.down * 0.2f;
        }

        // --------------------- Joystick movement ---------------------
        // MOVE LeftPad
        // horizontal
        movement += Vector3.right * moveVector.x;
        // vertical (fwd/back)
        movement += Vector3.forward * moveVector.y;
        // vertical 
        movement += Vector3.up * ( verticalMovement / 2.0f);


        // TILT RightPad
        // horizontal
        tilt += Vector3.up * lookVector.x;
        // vertical
        tilt += Vector3.right * -lookVector.y;


        player.transform.eulerAngles += tilt * tiltSpeed;

        // Rotate movement vector
        // Rotate along Y-axis
        movement = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * movement;
        movement = Quaternion.AngleAxis(transform.eulerAngles.x, Vector3.right) * movement;

        player.transform.position += movement * moveSpeed;
    }

    public void setAllowMovement(bool allowed)
    {
        movementAllowed = allowed;
    }
}
