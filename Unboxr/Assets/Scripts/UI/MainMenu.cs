using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject controlScreen;
    [SerializeField] private GameObject mainScreen;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenControls()
    {
        controlScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void Return()
    {
        mainScreen.SetActive(true);
        controlScreen.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
