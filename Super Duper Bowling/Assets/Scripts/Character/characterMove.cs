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
        }
        Collider col = GetComponentInChildren<Collider>();
        if (Input.GetKey(KeyCode.Space) && col != null && col.isTrigger == true)
        {
            // Only jump if there is something in the trigger
            Collider[] hits = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, ~0, QueryTriggerInteraction.Ignore);
            bool hasOtherCollider = false;
            foreach (var hit in hits)
            {
                if (hit != col && hit.attachedRigidbody != rb)
                {
                    hasOtherCollider = true;
                    break;
                }
            }

            if (hasOtherCollider && rb != null)
            {
                rb.AddForce(Vector3.up * 1f, ForceMode.Impulse);
            }
        }
        rb.AddForce(Vector3.up * 1f, ForceMode.Impulse);
    }
}
