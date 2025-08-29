using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Add this if using the new Input System

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject crosshair;

    public GameObject StartLevelMenuUI;
    void Start()
    {
        // Time.timeScale = 1f; // Ensure the game starts unpaused
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
        // GameIsPaused = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // crosshair.SetActive(true);
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // crosshair.SetActive(false);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
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
    public void NextLevel()
    {
        // Load the next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}