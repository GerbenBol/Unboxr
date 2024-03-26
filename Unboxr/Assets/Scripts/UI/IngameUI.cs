using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class IngameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI boxesLeftTMP;
    [SerializeField] private TextMeshProUGUI timerTMP;
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
        boxesLeftTMP.text = boxesStart + boxesLeft;
    }

    public void UpdateLockedEnabled()
    {
        lockedPanel.SetActive(true);
        StartCoroutine(EnableLocked());
    }

    private string FormatTime(float time)
    {
        TimeSpan ts = TimeSpan.FromSeconds(Convert.ToInt32(time));
        string seconds = ts.ToString(@"ss");
        return Convert.ToInt32(ts.TotalMinutes) + ":" + seconds;
    }

    private IEnumerator EnableLocked()
    {
        yield return new WaitForSeconds(2);
        lockedPanel.SetActive(false);
    }
}
