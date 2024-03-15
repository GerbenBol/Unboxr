using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject boxHolder;

    private IInteractable interactable;
    private PlayerInputs input;
    private bool holdingBox = false;
    private GameObject box;

    private void Awake()
    {
        input = new();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Interact.PickUp.performed += OnPickUp;
        input.Interact.OpenDoor.performed += OnOpenDoor;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
            interactable = other.GetComponent<Box>();
        else if (other.CompareTag("Door"))
            interactable = other.GetComponent<Door>();
    }

    private void OnTriggerExit(Collider other)
    {
        interactable = null;
    }

    private void OnPickUp(InputAction.CallbackContext context)
    {
        if (interactable == null)
            return;

        interactable.Interact();

        if (!holdingBox)
        {
            box = interactable.MyObject;
            holdingBox = true;
        }
        else
        {
            box = null;
            holdingBox = false;
        }
    }

    private void OnOpenDoor(InputAction.CallbackContext context)
    {
        if (interactable == null)
            return;

        interactable.Interact();
    }
}
