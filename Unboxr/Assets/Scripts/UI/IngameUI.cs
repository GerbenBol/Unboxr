using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class IngameUI : MonoBehaviour
{
    public enum InteractHelperState { BoxPickup, BoxDrop, DoorOpen, SetToDefault }

    [SerializeField] private TextMeshProUGUI boxesLeftTMP;
    [SerializeField] private TextMeshProUGUI timerTMP;
    [SerializeField] private TextMeshProUGUI interactHelper;
    [SerializeField] private GameObject lockedPanel;
    
    private readonly string boxesStart = "Boxes left: ";

    private void Update()
    {
        if (PauseScreen.GamePaused)
            return;

        LevelManager.timer += Time.deltaTime;
        timerTMP.text = FormatTime(LevelManager.timer);
    }

    public void ChangeBoxesText(int boxesLeft)
    {
        // Verander hoeveel dozen we over hebben op het scherm
        boxesLeftTMP.text = boxesStart + boxesLeft;
    }

    public void UpdateLockedEnabled()
    {
        // Laat zien dat de deur dicht is
        lockedPanel.SetActive(true);
        StartCoroutine(EnableLocked());
    }

    public void InteractHelper(InteractHelperState state)
    {
        interactHelper.text = state switch
        {
            InteractHelperState.BoxPickup => "Press E to pick up box",
            InteractHelperState.BoxDrop => "Press E to drop the box",
            InteractHelperState.DoorOpen => "Press F to open the door",
            _ => "",
        };
    }

    private string FormatTime(float time)
    {
        // Geef geformatteerde tijd terug
        TimeSpan ts = TimeSpan.FromSeconds(Convert.ToInt32(time));
        string seconds = ts.ToString(@"ss");
        return Convert.ToInt32(ts.TotalMinutes) + ":" + seconds;
    }

    private IEnumerator EnableLocked()
    {
        // Haal de "locked" message weg
        yield return new WaitForSeconds(2);
        lockedPanel.SetActive(false);
    }
}
