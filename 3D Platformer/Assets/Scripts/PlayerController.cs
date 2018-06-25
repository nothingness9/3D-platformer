using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float movementSpeed;
    Rigidbody rb;

    public float gravityScale;

    CharacterController controller;


    Vector3 movementVector;
    bool jumping;
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
        jumping = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        /*
        //make sure you are reading something
        if(!(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
        {
            
        }
        movementVector = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        rb.velocity = (movementVector.normalized * movementSpeed ) + (new Vector3(0, rb.velocity.y, 0));


        if (rb.velocity.y == 0 && jumping)
        {
            jumping = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumping = true;
        }*/
        movementVector = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")).normalized * movementSpeed + new Vector3( 0f,movementVector.y ,0f);


        if ( controller.isGrounded)
        {
            movementVector.y = 0f;
            //movementVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * movementSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                movementVector.y = jumpForce;
            }
        }
        

        movementVector.y = movementVector.y + (Physics.gravity.y * gravityScale);
        controller.Move(movementVector* Time.fixedDeltaTime);
    }

    public bool IsGrounded()
    {
        return controller.isGrounded;
    }
}
