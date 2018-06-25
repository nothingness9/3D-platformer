using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float movementSpeed;
    Rigidbody rb;
    LayerMask ground;

    public float gravityScale;

    CharacterController controller;


    Vector3 movementVector;
    bool jumping;
    // Use this for initialization
    void Start () {
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        jumping = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        if(Input.GetAxisRaw("Vertical")!=0f || Input.GetAxisRaw("Horizontal") != 0f)
        {

            movementVector = (transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")).normalized * movementSpeed;

        }else
        {
            print("lol");
            // float oldDrag = rb.drag;
            //float oldMass = rb.mass;

            //rb.drag = 2000;
            //rb.mass = 5;
            movementVector = new Vector3(0f, movementVector.y, 0f);

            //rb.drag = oldDrag;
            //rb.mass = oldMass;
        }

        movementVector.y = movementVector.y + (Physics.gravity.y * gravityScale);
        rb.velocity = movementVector * Time.fixedDeltaTime;


        /*
        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumping = true;
        }*/

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
        return true;
    }
}
