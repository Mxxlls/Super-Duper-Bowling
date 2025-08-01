using UnityEngine;
public class moveAdvanced : MonoBehaviour
{
    public float maxSpeed = 10f; // Maximum speed for the character
    public float acceleration = 10f; // Acceleration force applied when moving
    public float deceleration = 5f; // Deceleration force applied when not moving
    private float slideSpeed = 0f;
    private bool sliding = false; // Track sliding state
    private float sideSpeed = 0f;
    private int grounded = 0; // Counter for grounded state
    private Camera cam; // Reference to the camera component
    private Rigidbody rb; // Reference to the Rigidbody component
    public float slideBoost = 5f; // Additional speed boost when sliding
    public float slideAcceleration = 20f; // Acceleration force applied when sliding

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
    }
    // Stop sliding when the key is released
    private bool IsGrounded()
    {
        // Check if the character is grounded using a raycast
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        grounded = grounded + 1;
    }
    void OnTriggerExit(Collider other)
    {
        grounded = grounded - 1;
    }
    void Update()
    {
        if (rb == null) return;

        Vector3 currentVelocity = rb.linearVelocity;
        float forwardSpeed = Vector3.Dot(currentVelocity, transform.forward);
        float sideSpeed = Vector3.Dot(currentVelocity, transform.right);

        // Start sliding when key is pressed and speed is high enough
        if (Input.GetKeyDown(KeyCode.LeftCommand) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(1f, 0.5f, 1f);
            slideSpeed = Mathf.Max(forwardSpeed, sideSpeed) + slideBoost;
            sliding = true;
            // Clamp the camera's rotation to its current rotation while sliding
            //Vector3 euler = cam.transform.localEulerAngles;
            //cam.transform.localRotation = Quaternion.Euler(0f, euler.y, euler.z);
        }

        // Stop sliding when key is released
        if (Input.GetKeyUp(KeyCode.LeftCommand) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            sliding = false;
            slideSpeed = 0f;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (sliding && (forwardSpeed < slideSpeed))
        {
            rb.AddForce(transform.forward * slideAcceleration * Time.deltaTime, ForceMode.VelocityChange);
            slideSpeed -= 1 * Time.deltaTime; // Gradually reduce slide speed
            rb.AddForce(-transform.right * (sideSpeed * deceleration * Time.deltaTime));
        }
        if (!(Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.LeftControl)))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            if (Input.GetKey(KeyCode.W) && (forwardSpeed < maxSpeed))
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    if (forwardSpeed < maxSpeed / 2)
                    {
                        rb.AddForce(transform.forward * acceleration * Time.deltaTime / 2, ForceMode.VelocityChange);
                    }
                }
                else
                {
                    rb.AddForce(transform.forward * acceleration * Time.deltaTime, ForceMode.VelocityChange);
                }
            }
            else if (Input.GetKey(KeyCode.S) && (forwardSpeed > -maxSpeed))
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    if (forwardSpeed > -maxSpeed / 2)
                    {
                        rb.AddForce(-transform.forward * acceleration * Time.deltaTime / 2, ForceMode.VelocityChange);
                    }
                }
                else
                {
                    rb.AddForce(-transform.forward * acceleration * Time.deltaTime, ForceMode.VelocityChange);
                }
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            { }
            else
            {
                if (grounded > 0 && Mathf.Abs(forwardSpeed) > 0.01f)
                {
                    rb.AddForce(-transform.forward * (forwardSpeed * deceleration * Time.deltaTime));
                }
            }

            // Handle sideways movement
            if (Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.LeftControl))
            {
            }
            else
            {
                if (Input.GetKey(KeyCode.A) && sideSpeed > -maxSpeed)
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                    {
                        if (sideSpeed > -maxSpeed / 2)
                        {
                            rb.AddForce(-transform.right * acceleration * Time.deltaTime / 2, ForceMode.VelocityChange);
                        }
                    }
                    else
                    {
                        rb.AddForce(-transform.right * acceleration * Time.deltaTime, ForceMode.VelocityChange);
                    }
                }
                else if (Input.GetKey(KeyCode.D) && sideSpeed < maxSpeed)
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                    {
                        rb.AddForce(transform.right * acceleration * Time.deltaTime / 2, ForceMode.VelocityChange);
                    }
                    else
                    {
                        rb.AddForce(transform.right * acceleration * Time.deltaTime, ForceMode.VelocityChange);
                    }
                }
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            { }
            else
            {
                if (grounded > 0 && Mathf.Abs(sideSpeed) > 0.01f)
                {
                    rb.AddForce(-transform.right * (sideSpeed * deceleration * Time.deltaTime));
                }
            }

        }
    }
}