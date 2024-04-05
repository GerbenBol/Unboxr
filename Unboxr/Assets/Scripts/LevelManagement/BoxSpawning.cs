using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawning : MonoBehaviour
{
    [SerializeField] private int boxesLeft;
    [SerializeField] private GameObject boxPrefab;
    private IngameUI ui;

    private void Start()
    {
        LevelManager.CurrentSpawner = this;
        ui = GameObject.Find("UI").GetComponent<IngameUI>();
        ui.ChangeBoxesText(boxesLeft);
    }

    public void SpawnNewBox(Material mat)
    {
        if (boxesLeft > 0)
        {
            GameObject gO = Instantiate(boxPrefab, transform);
            gO.GetComponent<MeshRenderer>().material = mat;
            boxesLeft--;
            ui.ChangeBoxesText(boxesLeft);
        }
        else
            GameObject.Find("UI").GetComponent<PauseScreen>().GameOver();
    }
}
