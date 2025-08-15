using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Change "Tutorial" to "Level Select" when we have a completed level select menu
        SceneManager.LoadScene("Tutorial");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}