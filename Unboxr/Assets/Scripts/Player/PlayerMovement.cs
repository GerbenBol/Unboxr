using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    PlayerInputs input;

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

    private void OnMove()
    {
        Debug.Log("move");
    }

    private void OnLook()
    {
        Vector2 delta = input.Player.Look.ReadValue<Vector2>();


    }

    private void OnJump()
    {
        Debug.Log("im gonna break a mfers leg");
    }
}
