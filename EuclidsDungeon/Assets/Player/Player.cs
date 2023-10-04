using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f; // Regular movement speed

    [SerializeField]
    private float sprintSpeed = 10f; // Sprinting speed

    [SerializeField]
    private float rotationSpeed = 10f; // Rotation speed

    private Rigidbody rb;
    private Vector3 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the game window
    }

    private void Update()
    {
        // Input handling
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveInput = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Rotate the character based on mouse input
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.y += mouseX * rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(rotation);
    }

    private void FixedUpdate()
    {
        // Move the character
        Vector3 moveDirection = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * moveInput;
        Vector3 moveVelocity;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveVelocity = moveDirection * sprintSpeed;
        }
        else
        {
            moveVelocity = moveDirection * moveSpeed;
        }

        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
    }
}