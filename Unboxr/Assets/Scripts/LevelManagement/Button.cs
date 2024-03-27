using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Material wantedMaterial;
    private string wantedName;
    private bool completed = false;

    private void Start()
    {
        wantedMaterial = GetComponent<MeshRenderer>().material;
        wantedName = wantedMaterial.ToString().Split(' ')[0];
        LevelManager.AddButton(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box") && !completed)
        {
            // Check of het de juiste doos is
            if (collision.gameObject.GetComponent<MeshRenderer>().material.ToString().Split(' ')[0] == wantedName)
            {
                // Disable doos & button, geef info door aan level manager
                completed = true;
                collision.gameObject.GetComponent<Box>().Locked = true;
                LevelManager.CompleteButton(gameObject);
            }
            else
            {
                // Destroy doos
                PlayerInteract.holdingBox = false;
                collision.gameObject.GetComponent<Box>().Respawn();
                Destroy(collision.gameObject);
            }
        }
    }
}
