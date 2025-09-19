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

    public Camera cutSceneCam;
    public Camera playerCam;

    public Animator ballRoll;
    public Animator cameraMove;

    public GameObject fakeBall;
    public GameObject player;
    public Rigidbody playerRB;

    public bool doneAnim = false;
    public float animTime = 2.2f;
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();

        pauseMenuScript = GetComponent<PauseMenu>();
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameIsPaused = true;
        pauseMenuScript.enabled = false;
    }
    public void PlayGame()
    {
        StartAnimation();
        Time.timeScale = 1f;
        StartLevelMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fakeBall.SetActive(true);
        player.SetActive(false);
        pauseMenuScript.enabled = true;
    }
    public void StartAnimation()
    {
        ballRoll.SetTrigger("Active");
        cameraMove.SetTrigger("Active");
        playerCam.enabled = false;
        cutSceneCam.enabled = true;
    }
    public void LaunchPlayer()
    {
        //initialise the swap
        player.SetActive(true);
        fakeBall.SetActive(false);
        playerCam.enabled= true;
        cutSceneCam.enabled= false;
        GameIsPaused = false;
        PauseMenu.GameIsPaused = false;

        //launch the player
        playerRB.AddForce(Vector3.up * (+ 10f), ForceMode.Impulse);
        playerRB.AddForce(Vector3.right * (+20f), ForceMode.Impulse);

    }
    void update()
    {

    }
}
