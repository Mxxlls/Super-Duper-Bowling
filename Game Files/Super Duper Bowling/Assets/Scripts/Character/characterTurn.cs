using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterTurn : MonoBehaviour
{
    private Camera cam; // Reference to the camera component
    public Vector2 sensitivity; // Sensitivity for mouse movement

    private float slideLock = 0f; // Variable to store the slide lock value
    private bool sliding = false; // Track sliding state
    private float camAngle = 0;
    private bool isPaused = false;

    // Removed OnEnable, OnDisable, PauseScript, and ResumeScript methods as GameManager is not defined

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Remove or comment out these lines:
        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;
        cam = GetComponentInChildren<Camera>();
    }
    // Update is called once per frame
    void Update()
    {

        // Only allow camera movement if the game is not paused
        if (PauseMenu.GameIsPaused) return;
        if (StartLevelMenu.GameIsPaused) return;

        float mouseY = Input.GetAxis("Mouse Y");
        if (cam != null)
        {
            camAngle += mouseY * sensitivity.y * Time.deltaTime;
            camAngle = Mathf.Clamp(camAngle, -75, 75);
            cam.transform.localRotation = Quaternion.Euler(camAngle, 0f, 0f);
            // Ensure camAngle is clamped
        }
        //if (Input.GetKeyDown(KeyCode.LeftCommand) || Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //   sliding = true;
        // slideLock = Input.GetAxis("Mouse X"); // Fixed: removed 'float' to use the class field
        //}
        //if (Input.GetKeyUp(KeyCode.LeftCommand) || Input.GetKeyUp(KeyCode.LeftControl))
        //{
        //    sliding = false;
        //  slideLock = 0f;
        //}
        if (sliding)
        {
            // If sliding, lock the camera's rotation to its current state
            //cam.transform.localRotation = Quaternion.Euler(Mathf.Clamp(cam.transform.localEulerAngles.x, -50, 50), cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);
            return; // Skip further rotation logic while sliding
        }
        // Only allow camera rotation if the game is not paused
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * sensitivity.x);

        Vector3 currentRotation = transform.localEulerAngles;
    }
}
