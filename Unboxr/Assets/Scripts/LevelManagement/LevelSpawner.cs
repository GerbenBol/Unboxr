using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels;
    [SerializeField] private GameObject endVoid;
    [SerializeField] private IngameUI ui;

    public static int LastSpawned = 0;

    private readonly List<GameObject> spawned = new();

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
        else
            Instantiate(endVoid);
    }

    public void StartEnd()
    {
        foreach (GameObject obj in spawned)
            Destroy(obj);

        ui.RemoveText();
    }

    private void SpawnLevel(int index)
    {
        // Spawn level
        GameObject obj = Instantiate(levels[index]);
        LastSpawned = index;
        LevelManager.NextLevel();
        spawned.Add(obj);
    }
}
