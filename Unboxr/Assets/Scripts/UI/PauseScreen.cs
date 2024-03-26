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
        PauseGame(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
}
