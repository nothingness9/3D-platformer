using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float movementSpeed;
    Rigidbody rb;
    public LayerMask ground;

    public float gravityScale;

    CharacterController controller;


    Vector3 movementVector;
    bool grounded;
    bool jumping;
    // Use this for initialization
    void Start () {
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        grounded= false;
        jumping = true;
	}
	
	// Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, 0.5f, ground);

        movementVector = new Vector3(0f, movementVector.y, 0f) + (transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")).normalized * movementSpeed;


        //Debug.DrawRay(transform.position, transform.right * 0.5f, Color.red);
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !jumping)
            {
                movementVector = new Vector3(movementVector.x, jumpForce, movementVector.z);
                jumping = true;
                //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }else if (jumping)
            {
                jumping = false;
            }else if (!jumping)
            {
                movementVector = new Vector3(movementVector.x, 0f, movementVector.z);
            }
            
        }
        else
        {
            movementVector.y = movementVector.y + (Physics.gravity.y * gravityScale);
        }


        rb.velocity = movementVector * Time.smoothDeltaTime;

    }



	void FixedUpdate ()
    {

        
        
      

        

        
        


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
