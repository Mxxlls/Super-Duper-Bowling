using UnityEngine;

public class jumpAdvanced : MonoBehaviour
{
    public float jumpForce = 12;
    public float climbSpeed = 10;
    private float coyoteTime;
    public float coyoteLimit;
    private float coyoteTimer;
    private Rigidbody rb;
    private float jumpDelay = 0.1f;
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
        jumpDelay = jumpDelay + Time.deltaTime;

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
        if (Input.GetKey(KeyCode.Space))
            if (Input.GetKeyDown(KeyCode.Space) && coyoteLimit > coyoteTimer && jumpDelay > 0.6f)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                coyoteTimer = (coyoteLimit * 2);
                jumpDelay = 0f;
            }
            else if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                if (Vector3.Dot(currentVelocity, Vector3.up) < climbSpeed && Input.GetKey(KeyCode.Space))
                {
                    rb.AddForce(Vector3.up * jumpForce * 1000 * Time.deltaTime);
                }
            }
    }
}
