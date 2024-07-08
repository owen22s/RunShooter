using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpForce = 5.0f;
    public Transform playerCamera;
    public float cameraClamp = 85.0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float verticalVelocity = 0.0f;
    private float gravity = 9.8f;
    private float cameraVerticalAngle = 0.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        // Get input
        float moveForwardBackward = Input.GetAxis("Vertical");
        float moveLeftRight = Input.GetAxis("Horizontal");

        // Calculate move direction
        Vector3 move = transform.right * moveLeftRight + transform.forward * moveForwardBackward;
        moveDirection = move * speed;

        // Handle jumping and gravity
        if (characterController.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveDirection.y = verticalVelocity;

        // Move the player
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically
        cameraVerticalAngle -= mouseY;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -cameraClamp, cameraClamp);
        playerCamera.localEulerAngles = Vector3.right * cameraVerticalAngle;
    }
}
