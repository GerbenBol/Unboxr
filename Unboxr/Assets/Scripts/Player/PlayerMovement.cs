using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform cam;

    private Rigidbody rb;
    private PlayerInputs input;

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

    private void OnMove()
    {
        Vector3 move = input.Player.Move.ReadValue<Vector3>();
        Debug.Log(move);
        rb.AddRelativeForce(move * moveSpeed);
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
}
