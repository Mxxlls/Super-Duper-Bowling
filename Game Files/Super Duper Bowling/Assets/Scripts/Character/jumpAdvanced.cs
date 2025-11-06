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
    private bool isGrounded;
    public bool grounded = false;

    public AudioSource jumpSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coyoteTimer = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground") && !grounded)
        {
            grounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground") && grounded)
        {
            grounded = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 currentVelocity = rb.linearVelocity;
        if (jumpDelay > 0f)
        {
            JumpDelay();
        }

        if (coyoteTimer < coyoteLimit)
        {
            coyoteTimer = coyoteTimer + Time.deltaTime;
        }
        // Cast a ray downwards to check if the player is grounded
        RaycastHit hit;
        isGrounded = false;
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded == true || grounded == true || coyoteTimer < coyoteLimit && jumpDelay == 0f)
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    coyoteTimer = (coyoteLimit * 2);
                    jumpDelay = 0.6f;
                    jumpSound.Play();

                }
            }
            else if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                if (Vector3.Dot(currentVelocity, Vector3.up) < climbSpeed && Input.GetKey(KeyCode.Space))
                {
                    rb.AddForce(Vector3.up * jumpForce * 1000 * Time.deltaTime);
                }
            }
    }
    void JumpDelay()
    {
        jumpDelay -= Time.deltaTime;
        if (jumpDelay < 0f)
        {
            jumpDelay = 0f;
        }
    }
}

