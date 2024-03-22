using System;
using TMPro;
using UnityEngine;

public class IngameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI boxesLeftTMP;
    [SerializeField] private TextMeshProUGUI timerTMP;
    
    private readonly string boxesStart = "Boxes left: ";

    private void Update()
    {
        LevelManager.timer += Time.deltaTime;
        timerTMP.text = FormatTime(LevelManager.timer);
    }

    public void ChangeBoxesText(int boxesLeft)
    {
        boxesLeftTMP.text = boxesStart + boxesLeft;
    }

    private string FormatTime(float time)
    {
        TimeSpan ts = TimeSpan.FromSeconds(Convert.ToInt32(time));
        string seconds = ts.ToString(@"ss");
        Debug.Log(ts.TotalMinutes);
        return Convert.ToInt32(ts.TotalMinutes) + ":" + seconds;
    }
}
