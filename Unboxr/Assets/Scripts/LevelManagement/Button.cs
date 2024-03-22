using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] new private MeshRenderer renderer;
    
    private Material wantedMaterial;
    private string wantedName;
    private bool completed = false;

    private void Start()
    {
        wantedMaterial = renderer.material;
        wantedName = wantedMaterial.ToString().Split(' ')[0];
        LevelManager.AddButton(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box") && !completed)
        {
            // Check of het de juiste doos is
            if (other.GetComponent<MeshRenderer>().material.ToString().Split(' ')[0] == wantedName)
            {
                // Disable doos & button, geef info door aan level manager
                completed = true;
                other.GetComponent<Box>().Locked = true;
                LevelManager.CompleteButton(gameObject);
            }
            else
            {
                // Destroy doos
                PlayerInteract.holdingBox = false;
                other.GetComponent<Box>().Respawn();
                Destroy(other.gameObject);
            }
        }
    }
}
