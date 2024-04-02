using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class LevelManager
{
    public static List<Level> Levels = new();
    public static BoxSpawning CurrentSpawner;
    public static float timer = .0f;

    private static int currentLevel = 0;

    public static void AddLevel(Level lvl)
    {
        // Voeg level toe
        Levels.Add(lvl);
    }

    public static void NextLevel()
    {
        currentLevel++;
    }

    public static void RestartLevel()
    {
        timer = .0f;
        Levels[currentLevel].RestartLevel();
    }
}
