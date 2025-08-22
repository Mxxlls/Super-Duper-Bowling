using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartLevelMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject StartLevelMenuUI;
    public void PlayGame()
    {
        Time.timeScale = 1f;
        StartLevelMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameIsPaused = false;
        PauseMenu.GameIsPaused = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameIsPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
