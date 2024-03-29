using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private GameObject[] lights;

    private Material wantedMaterial;
    private string wantedName;
    private bool completed = false;

    private void Start()
    {
        wantedMaterial = GetComponent<MeshRenderer>().material;
        wantedName = wantedMaterial.ToString().Split(' ')[0];
        LevelManager.Levels[level].AddButton(gameObject);

        foreach (GameObject light in lights)
            light.GetComponent<Light>().color = wantedMaterial.color;
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
                LevelManager.Levels[level].CompleteButton(gameObject);
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

    public void LightSwitch(bool onOff, string mat)
    {
        // Check if we have to switch lights on/off
        if (mat == wantedName)
            foreach (GameObject light in lights)
                light.SetActive(onOff);
    }
}
