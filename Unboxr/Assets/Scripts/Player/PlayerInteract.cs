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
    private string interactableName = "";

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

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, .5f))
        {
            if (hit.collider.CompareTag("Box"))
            {
                interactableName = "Box";
                interactable = hit.collider.GetComponent<Box>();
            }
            else if (hit.collider.CompareTag("Door"))
            {
                interactableName = "Door";
                interactable = hit.collider.GetComponent<Door>();
            }
        }
    }

    private void OnPickUp(InputAction.CallbackContext context)
    {
        if (interactable == null || interactableName == "Door")
            return;

        interactable.Interact(boxHolder);

        if (!holdingBox)
            holdingBox = true;
        else
            holdingBox = false;
    }

    private void OnOpenDoor(InputAction.CallbackContext context)
    {
        if (interactable == null || interactableName == "Box")
            return;

        interactable.Interact();
    }
}
