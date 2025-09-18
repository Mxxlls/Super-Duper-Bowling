using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine.Animations;
public class StartLevelMenu : MonoBehaviour
{
    public static bool GameIsPaused = true;
    public GameObject StartLevelMenuUI;
    public PauseMenu pauseMenuScript;
    public Camera cutSceneCamera;
    public Camera playerCamera;
    public Animator ballRoll;
    public Animator cameraMove;

    public bool doneAnim = false;
    public float animTime = 2.2f;
    void Start()
    {
        pauseMenuScript = GetComponent<PauseMenu>();
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameIsPaused = true;
        pauseMenuScript.enabled = false;
    }
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
    public void StartAnimation()
    {
        ballRoll.SetTrigger("Active");
        cameraMove.SetTrigger("Active");
    }
    public void LaunchPlayer()
    {
        playerCamera.enabled = true;
        playerCamera = Camera.main;
        cutSceneCamera.enabled = false;
    }
    void update()
    {
        if (doneAnim == false)
        {
            animTime = animTime - Time.time;
            if (animTime < 0)
            {
                LaunchPlayer();
                doneAnim = true;
            }
        }
    }
}
