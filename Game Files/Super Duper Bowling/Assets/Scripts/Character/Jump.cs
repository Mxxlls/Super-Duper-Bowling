using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 200f; // Force applied when jumping
    private Rigidbody rb;
    private int jump = 0; // Counter for jump triggers
    private

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pins"))
        {

        }
        else
        {
            jump = jump + 1;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pins"))
        {
            
        }
        else
        {
            jump = jump - 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 currentVelocity = rb.linearVelocity;

        if (Input.GetKey(KeyCode.Space) && jump > 0 && Vector3.Dot(currentVelocity, Vector3.up) < 5)
        {
            // Apply a force to the Rigidbody to make the character jump
            float forwardSpeed = Vector3.Dot(currentVelocity, transform.forward);
            float sideSpeed = Vector3.Dot(currentVelocity, transform.right);

            // Adjust jump force based on current speed
            // Apply the jump force
            {
                rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }
}