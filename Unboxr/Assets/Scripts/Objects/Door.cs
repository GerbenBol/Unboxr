using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable, IDestructable
{
    public GameObject MyObject { get => gameObject; }

    [SerializeField] private Rigidbody rb;

    public void Interact()
    {
        Debug.Log("what");
        rb.freezeRotation = false;
        rb.transform.Rotate(new(0, -5, 0));
    }
}
