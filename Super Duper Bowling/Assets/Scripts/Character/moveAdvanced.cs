using UnityEngine;

public class moveAdvanced : MonoBehaviour
{
    public float maxSpeed = 10f; // Maximum speed for the character
    public float acceleration = 10f; // Acceleration force applied when moving
    public float deceleration = 5f; // Deceleration force applied when not moving
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null) return;

        Vector3 currentVelocity = rb.linearVelocity;
        float sideSpeed = Vector3.Dot(currentVelocity, transform.right);
        float forwardSpeed = Vector3.Dot(currentVelocity, transform.forward);

        if (Input.GetKey(KeyCode.W))
        {
            if (forwardSpeed < maxSpeed)
            {
                rb.AddForce(transform.forward * acceleration);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (forwardSpeed > -maxSpeed)
            {
                rb.AddForce(-transform.forward * acceleration);
            }
        }
        else
        {
            // Decelerate when not moving forward or backward
            rb.AddForce(-transform.forward * forwardSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (sideSpeed > -maxSpeed)
            {
                rb.AddForce(-transform.right * acceleration);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (sideSpeed < maxSpeed)
            {
                rb.AddForce(transform.right * acceleration);
            }
        }
        else
        {
            // Decelerate when not moving sideways
            rb.AddForce(-transform.right * sideSpeed);
        }
    }
}
