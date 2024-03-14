using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private IInteractable interactable;
    private PlayerInputs input;
    private bool holdingBox = false;
    private GameObject box;

    private void Start()
    {
        input = new();
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

    private void OnPickUp()
    {
        Debug.Log("pickup");
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

    private void OnOpenDoor()
    {
        interactable.Interact();
    }
}
