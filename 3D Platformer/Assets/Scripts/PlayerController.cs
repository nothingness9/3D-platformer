using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float movementSpeed;
    Rigidbody rb;
    Vector3 movementVector;
    bool jumping;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        jumping = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //make sure you are reading something
        if(!(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
        {
            movementVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            rb.velocity = (movementVector * movementSpeed * Time.fixedDeltaTime)+(new Vector3(0, rb.velocity.y, 0));
            
        }

        if (rb.velocity.y == 0 && jumping)
        {
            jumping = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            rb.AddForce(Vector3.up * jumpForce);
            jumping = true;
        }

    }
}
