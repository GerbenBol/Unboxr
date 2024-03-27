using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject controlScreen;
    [SerializeField] private GameObject mainScreen;

    public void StartGame()
    {
        // Start de game
        SceneManager.LoadScene(1);
    }

    public void OpenControls()
    {
        // Open het control scherm
        controlScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void Return()
    {
        // Open het main menu scherm
        mainScreen.SetActive(true);
        controlScreen.SetActive(false);
    }

    public void QuitGame()
    {
        // Ga uit play mode/ sluit game af
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
