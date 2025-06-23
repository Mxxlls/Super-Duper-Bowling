using UnityEngine;

public class characterTurn : MonoBehaviour
{
    public float sensitivity = 100f; // Sensitivity for mouse movement
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * sensitivity);
        float mouseY = Input.GetAxis("Mouse Y");
        Camera cam = GetComponentInChildren<Camera>();
        if (cam != null)
        {
            cam.transform.Rotate(Vector3.left * mouseY * sensitivity);
        }
        Vector3 currentRotation = transform.localEulerAngles;
    }
}

