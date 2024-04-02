using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;

public class Level : MonoBehaviour
{
    public bool Completed;
    public int LevelIndex;
    public GameObject BoxSpawner;

    private readonly Dictionary<GameObject, bool> buttons = new();
    private Door door;
    private readonly List<Box> boxes = new();

    // Restart necessities
    private LevelSpawner spawner;
    private GameObject player;
    [SerializeField] private GameObject playerSpawnPoint;

    private void Awake()
    {
        // Voeg level toe aan level manager
        LevelManager.AddLevel(this);

        // Vind de level spawner
        spawner = GameObject.Find("LevelSpawner").GetComponent<LevelSpawner>();
        player = GameObject.Find("Player");
    }

    public void AddButton(GameObject gO)
    {
        // Voeg button toe aan dictionary
        buttons.Add(gO, false);
    }

    public void AddDoor(GameObject gO)
    {
        // Voeg deur toe aan level
        door = gO.GetComponent<Door>();
    }

    public void AddBox(Box box)
    {
        // Voeg doos toe aan level
        boxes.Add(box);
    }

    public void SearchLights(bool onOff, string mat)
    {
        // Sent each button message
        foreach (KeyValuePair<GameObject, bool> kvp in buttons)
            kvp.Key.GetComponent<Button>().LightSwitch(onOff, mat);
    }

    public void CompleteButton(GameObject gO)
    {
        // Zet bijbehorende waarde naar true
        buttons[gO] = true;

        // Check alle buttons
        foreach (KeyValuePair<GameObject, bool> kvp in buttons)
            if (!kvp.Value)
                return;

        // Doe licht aan en maak level compleet
        door.TurnOnLight();
        Completed = true;

        if (LevelSpawner.LastSpawned != LevelIndex + 1)
            spawner.CompleteLevel(LevelIndex);
    }

    public void RestartLevel()
    {
        GameObject[] gOs = new GameObject[buttons.Count];
        int index = 0;

        foreach (KeyValuePair<GameObject, bool> kvp in buttons)
        {
            gOs[index] = kvp.Key;
            index++;
        }

        for (int i = 0; i < gOs.Length; i++)
            buttons[gOs[i]] = false;

        foreach (Box box in boxes)
            if (box != null)
                box.Restart();

        Completed = false;
        player.transform.position = playerSpawnPoint.transform.position;
    }
}
