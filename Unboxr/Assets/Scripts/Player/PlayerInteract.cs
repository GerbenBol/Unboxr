using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public static bool holdingBox = false;

    [SerializeField] private GameObject boxHolder;
    [SerializeField] private LayerMask objectMask;
    [SerializeField] private PauseScreen pause;

    private IInteractable interactable;
    private PlayerInputs input;
    private string interactableName = "";

    private void Awake()
    {
        input = new();
    }

    private void OnEnable()
    {
        // Enable input actions
        input.Enable();
        input.Interact.PickUp.performed += OnPickUp;
        input.Interact.OpenDoor.performed += OnOpenDoor;
        input.Interact.Pause.performed += OnPause;
    }

    private void OnDisable()
    {
        // Disable input actions
        input.Disable();
    }

    private void Update()
    {
        if (!PauseScreen.GamePaused)
        {
            // Check of we naar een object kijken of al een doos vast hebben
            if (holdingBox)
                return;
            else if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 3f, objectMask, QueryTriggerInteraction.Collide))
            {
                // Check welk object we hebben geraakt
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
            else
            {
                // Zet variables terug zodat interacts niks meer doen
                interactableName = "";
                interactable = null;
            }
        }
    }

    private void OnPickUp(InputAction.CallbackContext context)
    {
        if (!PauseScreen.GamePaused)
        {
            // Check of het object een doos is en of we geen doos vasthebben
            if (!holdingBox)
                if (interactable == null || interactableName == "Door")
                    return;

            interactable.Interact(boxHolder);

            if (!holdingBox)
                holdingBox = true;
            else
                holdingBox = false;
        }
    }

    private void OnOpenDoor(InputAction.CallbackContext context)
    {
        if (!PauseScreen.GamePaused)
        {
            // Check of het object een deur is en of we een doos vasthebben
            if (interactable == null || interactableName == "Box" || holdingBox)
                return;

            interactable.Interact();
        }
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        pause.PauseGame(!PauseScreen.GamePaused);
    }
}
