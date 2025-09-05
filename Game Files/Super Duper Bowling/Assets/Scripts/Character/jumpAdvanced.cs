using UnityEngine;

public class jumpAdvanced : MonoBehaviour
{
    public float jumpForce = 10;
    public float climbSpeed = 10;
    private float coyoteTime;
    public float coyoteLimit;
    private float coyoteTimer;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coyoteTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentVelocity = rb.linearVelocity;

        if (coyoteTimer < coyoteLimit)
        {
            coyoteTimer = coyoteTimer + Time.deltaTime;
        }
        // Cast a ray downwards to check if the player is grounded
        RaycastHit hit;
        bool isGrounded = false;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                isGrounded = true;
            }
        }
        if (isGrounded == true)
        {
            coyoteTimer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && coyoteLimit > coyoteTimer)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("jump");
            coyoteTimer = coyoteLimit;
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            Debug.Log("part one");
            if (Vector3.Dot(currentVelocity, Vector3.up) < climbSpeed && Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce * 600 * Time.deltaTime);
                Debug.Log("part two");
            }
        }
    }
}
