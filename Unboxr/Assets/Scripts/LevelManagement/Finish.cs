using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private LevelSpawner spawner;

    private void Start()
    {
        spawner = GameObject.Find("LevelSpawner").GetComponent<LevelSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawner.StartEnd();
            GameObject.Find("EndVoid(Clone)").GetComponent<EndVoid>().StartVoid();
        }
    }
}
