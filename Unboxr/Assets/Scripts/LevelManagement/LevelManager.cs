using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelManager
{
    public static bool LevelCompleted = false;

    private static Dictionary<GameObject, bool> buttons = new();

    public static void AddButton(GameObject gO)
    {
        buttons.Add(gO, false);
    }

    public static void CompleteButton(GameObject gO)
    {
        buttons[gO] = true;

        foreach (KeyValuePair<GameObject, bool> kvp in buttons)
            if (!kvp.Value)
                return;
        Debug.Log(true);
        LevelCompleted = true;
    }
}
