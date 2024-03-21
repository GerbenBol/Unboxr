using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable, IDestructable
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private new GameObject light;
    [SerializeField] private Material material;

    private void Start()
    {
        LevelManager.AddDoor(gameObject);
    }

    public void Interact(GameObject boxHolder = null)
    {
        // Disable lock
        if (LevelManager.LevelCompleted)
        {
            rb.freezeRotation = false;
            rb.AddRelativeForce(new(500, 0, 0));
        }
    }

    public void TurnOnLight()
    {
        Debug.Log("turn on light");
        light.GetComponent<MeshRenderer>().material = material;
    }
}
