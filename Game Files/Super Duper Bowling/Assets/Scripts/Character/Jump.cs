using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 5f; // Force applied when jumping
    private Rigidbody rb;
    private int jump = 0; // Counter for jump triggers

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnTriggerEnter(Collider other)
    {
        jump = jump + 1;
    }
    void OnTriggerExit(Collider other)
    {
        jump = jump - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}