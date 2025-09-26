using UnityEngine;
using UnityEngine.AI;

public class enemyPin : MonoBehaviour
{
    private Rigidbody rb;
    private NavMeshAgent navAgent;
    public float Fly = 5f;
    public float Nyoom = 25f;
    public float Whoop = 10f;
    private float forwardSpeed = 0f;
    public Transform player;
    private float goAmount = 0f;
    public Rigidbody rbp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentVelocity = rbp.linearVelocity;
        forwardSpeed = Vector3.Dot(currentVelocity, transform.forward + transform.right);
        goAmount = Mathf.Abs(forwardSpeed) / 180;

        // Despawn pin if it falls below -10 on the y-axis
        if (transform.position.y < -10f)
        {
            GameObject winVarObj = GameObject.Find("Win Var");
            if (winVarObj != null)
            {
                Winscript winScript = winVarObj.GetComponent<Winscript>();
                if (winScript != null)
                {
                    winScript.pins += 1;
                }
            }
            Destroy(gameObject);
        }
    }
    // Called when another collider enters the trigger collider attached to this object
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable the second collider in the list (if it exists)
            Collider[] colliders = GetComponents<Collider>();
            if (colliders.Length > 1 && colliders[1] != null)
            {
                colliders[1].enabled = false;
            }

            // Handle player collision
            // rbp is player rb
            Debug.Log("Player collided with enemy pin");
            // Unfreeze rotation and position
            rb.constraints = RigidbodyConstraints.None;
            if (rb != null)
            {
                Vector3 awayFromPlayer = transform.position - other.transform.position;
                awayFromPlayer.y = 0f;
                awayFromPlayer = awayFromPlayer.normalized;
                rb.AddForce(awayFromPlayer * ((Nyoom * goAmount) + 0.1f), ForceMode.Impulse);
                rb.AddForce(Vector3.up * ((Fly * goAmount) + 0.1f), ForceMode.Impulse);
                Vector3 torqueDirection = Vector3.Cross(Vector3.up, awayFromPlayer).normalized;
                rb.AddTorque(torqueDirection * ((Whoop * goAmount) + 0.1f), ForceMode.Impulse);
            }
        }
    }
}