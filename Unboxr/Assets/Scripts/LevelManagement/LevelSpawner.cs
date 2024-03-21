using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels;

    private void Start()
    {
        // Spawn eerste level
        if (levels.Count != 0)
            SpawnLevel(0);
    }

    public void CompleteLevel(int index)
    {
        // Level completed handling
        if (index + 1 > levels.Count)
            SpawnLevel(index + 1);
    }

    private void SpawnLevel(int index)
    {
        // Spawn level
        Instantiate(levels[index]);
    }
}
