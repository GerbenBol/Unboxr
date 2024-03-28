using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public bool Completed;
    public int LevelIndex;

    private readonly Dictionary<Button, bool> buttons = new();
    private Door door;

    private void Start()
    {
        
    }

    public void AddButton(GameObject gO)
    {
        // Voeg button toe aan dictionary
        buttons.Add(gO.GetComponent<Button>(), false);
    }

    public void AddDoor(GameObject gO)
    {
        // Voeg deur toe aan level
        door = gO.GetComponent<Door>();
    }
}
