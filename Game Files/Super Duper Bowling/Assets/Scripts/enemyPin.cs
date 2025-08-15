using UnityEngine;

public class enemyPin : MonoBehaviour
{
    private Rigidbody rb;
    private Rigidbody rbp;
    public float Fly = 5f;
    public float Nyoom = 25f;
    public float Whoop = 10f;
    private float forwardSpeed = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called when another collider enters the trigger collider attached to this object
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rbp = other.GetComponent<Rigidbody>();

            Vector3 currentVelocity = rbp.linearVelocity;
            float forwardSpeed = Vector3.Dot(currentVelocity, transform.forward);
            // Handle player collision
            // rbp is player rb
            Debug.Log("Player collided with enemy pin");
            if (rb != null)
            {
                Fly = (Fly * forwardSpeed / 2) + 5;
                Nyoom = (Nyoom * forwardSpeed / 2) + 5;
                Whoop = (Whoop * forwardSpeed / 2) + 5;
                rb.AddForce(Vector3.up * Fly, ForceMode.Impulse);
                rb.AddForce(Vector3.forward * Nyoom, ForceMode.Impulse);
                rb.AddTorque(Vector3.right * Whoop, ForceMode.Impulse);
            }
            GetComponent<CapsuleCollider>().enabled = false;


            if (transform.position.y < -50f)
            {
                Destroy(gameObject);
            }
        }
    }
}