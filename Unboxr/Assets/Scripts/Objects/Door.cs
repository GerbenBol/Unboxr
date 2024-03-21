using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable, IDestructable
{
    [SerializeField] private Rigidbody rb;

    public void Interact(GameObject boxHolder = null)
    {
        // Disable lock
        rb.freezeRotation = false;
        rb.AddRelativeForce(new(500, 0, 0));
    }
}
