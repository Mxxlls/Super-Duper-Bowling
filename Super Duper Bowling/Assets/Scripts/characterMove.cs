using UnityEngine;

public class characterMove : MonoBehaviour
{
    public float maxspeed = 10f; // Maximum speed for the character
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float sideSpeed = Vector3.Dot(rb.linearVelocity, transform.right);
        float forwardSpeed = Vector3.Dot(rb.linearVelocity, transform.forward);
        if (Input.GetKey(KeyCode.W))
        {

            if (rb != null && forwardSpeed < maxspeed)
            {
                rb.AddForce(transform.forward * 10f);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (rb != null && forwardSpeed > -maxspeed)
            {
                rb.AddForce(-transform.forward * 10);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (rb != null && sideSpeed > -maxspeed)
            {
                rb.AddForce(-transform.right * 10f);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (rb != null && sideSpeed < maxspeed)
            {
                rb.AddForce(transform.right * 10f);
            }
            if (Input.GetKey(KeyCode.Space) && !GetComponentInChildren<trigger>() = true)
            {
                rb.AddForce(Vector3.up * 1f, ForceMode.Impulse);
            }
        }
    }
}
