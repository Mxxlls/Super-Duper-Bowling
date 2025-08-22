using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class StartLevelMenu : MonoBehaviour
{
    public static bool GameIsPaused = true;
    public GameObject StartLevelMenuUI;
    public PauseMenu pauseMenuScript;
    public void PlayGame()
    {
        Time.timeScale = 1f;
        StartLevelMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameIsPaused = false;
        PauseMenu.GameIsPaused = false;
        pauseMenuScript.enabled = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenuScript = GetComponent<PauseMenu>();
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameIsPaused = true;
            pauseMenuScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
