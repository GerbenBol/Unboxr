using System.Collections.Generic;

public static class LevelManager
{
    public static List<Level> Levels = new();
    public static BoxSpawning CurrentSpawner;
    public static float timer = .0f;

    private static int currentLevel = -1;
    private static float timerCP = .0f;

    public static void AddLevel(Level lvl)
    {
        // Voeg level toe
        Levels.Add(lvl);
    }

    public static void NextLevel()
    {
        // Update variables
        currentLevel++;
        timerCP = timer;
    }

    public static void RestartLevel()
    {
        // Restart level
        timer = timerCP;
        Levels[currentLevel].RestartLevel();
    }
}
