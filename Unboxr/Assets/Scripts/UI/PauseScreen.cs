using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public static bool GamePaused = false;

    [SerializeField] private GameObject screen;

    public void PauseGame(bool state)
    {
        // Pauseer de game
        screen.SetActive(state);
        GamePaused = state;
        Cursor.visible = state;

        if (state)
            Cursor.lockState = CursorLockMode.Confined;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void Continue()
    {
        // Ga weer door met het spel
        PauseGame(false);
    }

    public void Retry()
    {
        // Restart het level
        Continue();
        LevelManager.RestartLevel();
    }

    public void ReturnToMain()
    {
        // Ga terug naar de main menu
        SceneManager.LoadScene(0);
    }
}
