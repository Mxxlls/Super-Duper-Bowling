using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine.Animations;
public class StartLevelMenu : MonoBehaviour
{
    public static bool GameIsPaused = true;
    public GameObject StartLevelMenuUI;
    private PauseMenu pauseMenuScript;

    public Camera cutSceneCam;
    private Camera playerCam;
    public GameObject OtherCamGameObject;
    public GameObject playerCamGameObject;

    public Animator ballRoll;
    public Animator cameraMove;

    public GameObject fakeBall;
    public GameObject player;
    private Rigidbody playerRB;
    public GameObject timeCounter;

    public AudioSource gameMusic;

    public bool doneAnim = false;
    public float animTime = 2.2f;
    public TimerController timerController; // Add this at the top with other public fields
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
        pauseMenuScript = GetComponent<PauseMenu>();
        playerCam = player.GetComponentInChildren<Camera>();
        playerRB = player.GetComponent<Rigidbody>();
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameIsPaused = true;
        pauseMenuScript.enabled = false;
        playerCamGameObject.SetActive(false);
        playerCam.enabled = false;
    }
    public void PlayGame()
    {
        gameMusic.Play();

        if (!cutSceneCam)
        {
            GameIsPaused = false;
            PauseMenu.GameIsPaused = false;
        }
        else
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
        OtherCamGameObject.SetActive(true);
        cutSceneCam.enabled = true;
    }
    public void LaunchPlayer()
    {
        //initialise the swap
        player.SetActive(true);
        fakeBall.SetActive(false);
        playerCamGameObject.SetActive(true);
        playerCam.enabled = true;
        OtherCamGameObject.SetActive(false);
        cutSceneCam.enabled = false;
        GameIsPaused = false;
        PauseMenu.GameIsPaused = false;

        //timer
        timeCounter.SetActive(true);
        timerController.StartTimer();
        Debug.LogWarning("Timer started");

        //launch the player
        player.GetComponentInChildren<MeshRenderer>().enabled = false; //hides player
        playerRB.AddForce(Vector3.up * (+10f), ForceMode.Impulse);
        playerRB.AddForce(Vector3.right * (+20f), ForceMode.Impulse);

    }
}
