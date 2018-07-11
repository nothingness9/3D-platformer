using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float movementSpeed;
    Rigidbody rb;
    public LayerMask ground;

    public float groundDistance;

    public float deathMultiplier;

    float currentVerticalDistance;

    public float gravityScale;

    CharacterController controller;


    Vector3 movementVector;
    bool grounded;
    bool jumping;

    RaycastHit hit;

    ///////////////////////////
    //Falling control
    bool falling;
    Vector3 lastPosition;
    Transform lastPaltform;



    // Use this for initialization
    void Start () {
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        grounded= false;
        falling = true;
        jumping = true;
        currentVerticalDistance = -1f;
	}

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position

        Debug.DrawRay(transform.position, Vector3.down * 0.525f, Color.red);
    }
	
	// Update is called once per frame
    void Update()
    {


        movementVector = new Vector3(0f, movementVector.y, 0f) + (transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")).normalized * (movementSpeed/Time.fixedDeltaTime);


        
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !jumping)
            {
                movementVector = new Vector3(movementVector.x, jumpForce*2f/(Time.fixedDeltaTime), movementVector.z);
                jumping = true;
                lastPosition = transform.position;
                //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }

        }




    }



	void FixedUpdate ()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, out hit, 0.525f, ground);

        if (grounded)
        {
            if (lastPaltform != hit.transform && !falling)
            {
                lastPaltform = hit.transform;
            }
            if (falling)
            {
                falling = false;
            }
            if (jumping)
            {
                jumping = false;
            }
            else if (!jumping)
            {
                currentVerticalDistance = currentVerticalDistance - transform.position.y;
                if (currentVerticalDistance >= deathMultiplier*jumpForce)
                {
                    transform.position = lastPaltform.position + new Vector3(0f, groundDistance, 0f);
                    print("you are already dead");
                }
                currentVerticalDistance = -1;
                movementVector = new Vector3(movementVector.x, 0f, movementVector.z);
            }

        }
        else
        {
            if (!falling)
            {
                falling = true;
            }
            movementVector.y = movementVector.y + (Physics.gravity.y * gravityScale);
            if(movementVector.y<0f && currentVerticalDistance == -1f)
            {
                currentVerticalDistance = transform.position.y;
            }
        }

        rb.velocity = movementVector * Time.fixedDeltaTime;










        /*
        */

        /*
        if ( controller.isGrounded)
        {
            movementVector.y = 0f;
            //movementVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * movementSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                movementVector.y = jumpForce;
            }
        }*/


        //movementVector.y = movementVector.y + (Physics.gravity.y * gravityScale);
        //controller.Move(movementVector* Time.smoothDeltaTime);
    }

    public bool IsGrounded()
    {
        return grounded;
    }
}
