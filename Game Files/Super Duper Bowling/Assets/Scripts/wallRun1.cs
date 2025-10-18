
using System;
using UnityEngine;

// https://www.youtube.com/watch?v=4lkuqPkeAcw
// this script needs a rigidbody type controller
// public float camAngle = 20; - this cam angle value needs to be same as cam angle value set in inspector


public class wallRun1 : MonoBehaviour
{
    [Header("Properties")]


    public bool isWallRunning = false; //If the player is currently WallRunning or not, not wall running at start
    public float wallRunDuration = 4; //The second before stop wallrun.
    public float upForce = 75f; // The vertical force applied when the player begins wallRun.
    public float constantUpForce = 500f;// The vertical force to not let the player fall.
    public float wallJumpForce = 30f;

    [Header("Camera")]

    public float rayDistance;
    public float camAngle = 30;
    //public float wallBoost = 100;
    public float curCamAngle;
    public Transform cam;

    private Vector3 wallDir; //The direction to the wall
    [Header("Controller")]
    public Rigidbody FirstPersonController; // Your Controller

    public Rigidbody rb; // The rigidbody, now known as rb

    public static wallRun1 instance;

    private bool isCancellingWallrunning;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        instance = this;
        wallDir = Vector3.up; // vertical
    }

    private void Update()
    {
        WallRunning(); //method - this is what wall running is, currently if fpc camera is within a certain angle of the wall
        if (cam != null) // camera transform is not equal to null - check raycast to the left and the right
        {
            if (Physics.Raycast(transform.position, transform.right, rayDistance)) //to the right
            {
                curCamAngle = camAngle;

            }
            else if (Physics.Raycast(transform.position, -transform.right, rayDistance)) //to the left, which is -right
            {
                curCamAngle = -camAngle;
            }
            else
            {
                curCamAngle = 0; // not wallrunning
            }
        }
    }


    private void EnterInWall()
    {

        if (!isWallRunning) // if we arent already wallrunning, do this stuff below
        {
            //rb.AddForce(Vector3.up * upForce, ForceMode.Impulse); // gives upward impulse/jump effect at start of the wallride
            //rb.AddForce(Vector3.up * camAngle * 0.7f, ForceMode.Impulse); -------------------------------------------------------this gives more boost

            Debug.Log("Start Wall Run");
        }

        isWallRunning = true;
    }

    private void WallRunning()
    {
        if (isWallRunning) // if currently wallrunning
        {
            rb.AddForce(-wallDir * 4500 * Time.deltaTime); // Push the player forwards on the wall, by value (4500)
            rb.AddForce(Vector3.up * constantUpForce * Time.deltaTime); // Apply a constant force to not let the player fall off of the wall.

            {
                //if (Input.GetKeyDown("space"))
                //if (Input.GetButtonDown("Jump")) //or GetButtonDown to jump with press duration
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isWallRunning = false;
                    Invoke("ExitWallRunning", wallRunDuration * Time.deltaTime);


                    //rb.AddForce(new Vector3(-2, 0, 0), ForceMode.Impulse);
                    rb.AddRelativeForce(new Vector3(0, 0.2f, 1), ForceMode.Impulse);
                    //rb.AddForce(-wallDir * 4500 * Time.deltaTime);
                    //rb.AddRelativeForce(-wallDir * 10 * wallJumpForce);  // throws me in the direction of the wall

                    //rb.AddForce(Camera.main.transform.forward * Time.deltaTime * 100); -------------------------------------------------------------------------
                    //rb.AddForce(rb.velocity.normalized * Time.deltaTime * 100); // should add force in current rb direction
                }
            }
        }
    }

    //Check the angle of the surface.
    private bool CheckSurfaceAngle(Vector3 v, float angle)
    {
        return Math.Abs(angle - Vector3.Angle(Vector3.up, v)) < 0.1f;
    }


    private void ExitWallRunning()
    {
        isWallRunning = false; //exiting the wall run
    }


    private void OnCollisionStay(Collision other)
    {
        Vector3 surface = other.contacts[0].normal;
        if (CheckSurfaceAngle(surface, 90)) //if the surface is rotated 90 degrees (meaning it is a wall) 
        {
            EnterInWall();
            wallDir = surface;

            isCancellingWallrunning = false;
            CancelInvoke("ExitWallRunning");
        }

        if (!isCancellingWallrunning)
        {
            isCancellingWallrunning = true;
            Invoke("ExitWallRunning", wallRunDuration * Time.deltaTime);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (isWallRunning)
        {
            ExitWallRunning();

        }

    }

}

