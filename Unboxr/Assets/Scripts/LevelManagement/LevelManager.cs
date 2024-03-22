using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class LevelManager
{
    public static bool LevelCompleted = false;
    public static BoxSpawning CurrentSpawner;
    public static float timer = .0f;

    private static readonly Dictionary<GameObject, bool> buttons = new();
    private static Door door;

    public static void AddButton(GameObject gO)
    {
        // Voeg buttons toe aan dictionary
        buttons.Add(gO, false);
    }

    public static void AddDoor(GameObject gO)
    {
        // Voeg deur van level toe
        door = gO.GetComponent<Door>();
    }

    public static void CompleteButton(GameObject gO)
    {
        // Zet bijbehorende waarde naar true
        buttons[gO] = true;

        // Check alle buttons
        foreach (KeyValuePair<GameObject, bool> kvp in buttons)
            if (!kvp.Value)
                return;

        // Doe licht aan en maak level compleet
        door.TurnOnLight();
        LevelCompleted = true;
    }
}
