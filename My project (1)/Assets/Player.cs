using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cam;
    public Collider hitbox;
    public Rigidbody body;
    public float MouseSensitivity = 5;
    public float MoveSpeed = 5.0f;
    public float JumpForce = 10;

    private float verticalLookRotation = 0f;

    void Start()
    {
        cam = Camera.main.transform;
        hitbox = GetComponent<Collider>();
        body = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to the center of the screen
    }

    void Update()
    {
        // Look around horizontally
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        body.MoveRotation(body.rotation * Quaternion.Euler(new Vector3(0f, mouseX, 0f)));

        // Look around vertically
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;
        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f); // Clamp vertical rotation to prevent flipping
        cam.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);

        // Move the player
        float moveX = Input.GetAxis("Horizontal") * MoveSpeed;
        float moveZ = Input.GetAxis("Vertical") * MoveSpeed;
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        body.velocity = move;

        // Jump if grounded and space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            body.velocity = new Vector3(body.velocity.x, JumpForce, body.velocity.z);
        }
    }

    bool Grounded()
    {
        // Check if there's ground beneath the player
        bool cast = Physics.Raycast(transform.position, Vector3.down, 0.8f, LayerMask.GetMask("Default"));
        return cast;
    }
}