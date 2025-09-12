using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
public class StartLevelMenu : MonoBehaviour
{
    public static bool GameIsPaused = true;
    public GameObject StartLevelMenuUI;
    public PauseMenu pauseMenuScript;
    public Camera cutSceneCamera;
    public Camera playerCamera;

    public Animation ballRoll;
    public Animation cameraMove;

    public void PlayGame()
    {
        Time.timeScale = 1f;
        StartLevelMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameIsPaused = false;
        PauseMenu.GameIsPaused = false;
        pauseMenuScript.enabled = true;
        StartAnimation();
    }

    void Start()
    {
        pauseMenuScript = GetComponent<PauseMenu>();
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameIsPaused = true;
            pauseMenuScript.enabled = false;
    }

    public void StartAnimation()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
