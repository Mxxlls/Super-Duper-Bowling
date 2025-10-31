using UnityEditor;
using UnityEngine;

public class wallRun : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused) return;
        if (StartLevelMenu.GameIsPaused) return;
        if (Winscript.GameIsPaused) return;
        if (player == null) return;

        RaycastHit hit;

        if (Physics.Raycast(player.transform.position, player.transform.right, out hit, 1f))
        {
            player.GetComponent<Rigidbody>().useGravity = false;
            Vector3 vel = player.GetComponent<Rigidbody>().linearVelocity;
            vel.y = 0;
            player.GetComponent<Rigidbody>().linearVelocity = vel;
        }
        else if (Physics.Raycast(player.transform.position, -player.transform.right, out hit, 1f))
        {
            player.GetComponent<Rigidbody>().useGravity = false;
            Vector3 vel = player.GetComponent<Rigidbody>().linearVelocity;
            vel.y = 0;
            player.GetComponent<Rigidbody>().linearVelocity = vel;
        }
        else
        {
            player.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
