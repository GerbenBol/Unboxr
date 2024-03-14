using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxSprint;
    [SerializeField] private Transform cam;

    private Rigidbody rb;
    private PlayerInputs input;
    private Vector3 move = new(0, 0, 0);
    private bool sprinting = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = new();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        float speed = .5f;

        if (sprinting)
        {
            if (rb.velocity.magnitude + move.magnitude < maxSprint)
                speed = sprintSpeed;
        }
        else if (rb.velocity.magnitude + move.magnitude < maxSpeed)
            speed = moveSpeed;

        rb.AddRelativeForce(2 * speed * move);
    }

    private void OnMove()
    {
        move = input.Player.Move.ReadValue<Vector3>();
    }

    private void OnLook()
    {
        Vector2 delta = input.Player.Look.ReadValue<Vector2>();
        float dTime = Time.deltaTime * 25;
        
        cam.Rotate(delta.y * -dTime, 0, 0);
        transform.Rotate(0, delta.x * dTime, 0);
    }

    private void OnJump()
    {
        rb.AddForce(new(0, jumpForce));
    }

    private void OnSprint()
    {
        if (!sprinting)
            sprinting = true;
        else
            sprinting = false;
    }
}
