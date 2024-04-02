using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels;

    public static int LastSpawned = 0;

    private void Start()
    {
        // Spawn eerste level
        if (levels.Count != 0)
            SpawnLevel(0);
    }

    public void CompleteLevel(int index)
    {
        int nextLevel = index + 1;

        // Level completed handling
        if (nextLevel < levels.Count)
            SpawnLevel(nextLevel);
    }

    private void SpawnLevel(int index)
    {
        // Spawn level
        Instantiate(levels[index]);
        LastSpawned = index;
        LevelManager.NextLevel();
    }
}
