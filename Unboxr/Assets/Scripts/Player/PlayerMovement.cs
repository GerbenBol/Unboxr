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
    private float originalDrag;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = new();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        originalDrag = rb.drag;
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
        if (!PauseScreen.GamePaused)
        {
            // Add movement
            float speed = .5f;

            if (sprinting && rb.velocity.magnitude + move.magnitude < maxSprint)
                speed = sprintSpeed;
            else if (rb.velocity.magnitude + move.magnitude < maxSpeed)
                speed = moveSpeed;

            rb.AddRelativeForce(2 * speed * move);

            // Ground check
            if (GroundCheck())
                rb.drag = originalDrag;
            else
                rb.drag = 0;
        }
    }

    private void OnMove()
    {
        // Store movement inputs
        move = input.Player.Move.ReadValue<Vector3>();
    }

    private void OnLook()
    {
        if (!PauseScreen.GamePaused)
        {
            // Verander camera aan de hand van muis movements
            Vector2 delta = input.Player.Look.ReadValue<Vector2>();
            float dTime = Time.deltaTime * 20;

            cam.Rotate(delta.y * -dTime, 0, 0);
            transform.Rotate(0, delta.x * dTime, 0);
        }
    }

    private void OnJump()
    {
        if (!PauseScreen.GamePaused)
        {
            // Jump
            if (GroundCheck())
            {
                rb.drag = 0;
                rb.AddForce(new(0, jumpForce));
            }
        }
    }

    private void OnSprint()
    {
        // Store sprint variables
        if (!sprinting)
            sprinting = true;
        else
            sprinting = false;
    }

    private bool GroundCheck()
    {
        // Check of we op de grond staan
        Vector3 pos = transform.position;
        Vector3 scale = transform.localScale;
        pos.y -= transform.lossyScale.y / 2;
        scale.y = .2f;

        return Physics.BoxCast(pos, scale, Vector3.down, Quaternion.identity, .5f);
    }
}
