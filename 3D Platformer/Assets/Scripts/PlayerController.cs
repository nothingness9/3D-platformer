using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {

    public float jumpHeight;
    public float movementSpeed;
    Rigidbody rb;
    public LayerMask ground;

    public float groundDistance;

    public float deathMultiplier;

    float currentVerticalDistance;

    public float gravityScale;


    Vector3 movementVector;
    bool grounded;
    bool jumping;

    public Vector3[] raycastPositions;

    RaycastHit[] hit;

    

    ///////////////////////////
    //Falling control
    bool falling;
    Vector3 lastPosition;
    Transform newPlatform;
    Transform lastPaltform;

    ///////////////////////////
    // Interaction variables
    ///////////////////////////

    // Interaction variables
    public InteractionDetector interaction;

    public InteractiveObject interactableObject;

    // Use this for initialization
    void Start () {
        //controller = GetComponent<CharacterController>();
        hit = new RaycastHit[raycastPositions.Length];
        rb = GetComponent<Rigidbody>();
        grounded= false;
        falling = true;
        jumping = true;
        currentVerticalDistance = -1f;
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Vector3 v in raycastPositions)
        {
            Debug.DrawRay(transform.position + v, transform.up * -1 * groundDistance, Color.red);
        }
        //Gizmos.DrawWireSphere(transform.position+ transform.up * -1 * sphereDistance, sphereRadious);
       
    }
    void Awake()
    {

        interaction.SetParent(this);
        
    }

    // Update is called once per frame
    void Update()
    {


        movementVector = new Vector3(0f, 0f, 0f) + (transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")).normalized * movementSpeed;


        
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !jumping)
            {
                //movementVector = new Vector3(movementVector.x, jumpForce*2, movementVector.z);
                rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(-2 * jumpHeight / gravityScale * Physics.gravity.y),rb.velocity.z);
                jumping = true;
                lastPosition = transform.position;
                //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }

        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            //print(hit.transform);
        }




    }



	void FixedUpdate ()
    {
        //(Physics.SphereCast(p1, charCtrl.height / 2, transform.forward, out hit, 10)
        //Physics.SphereCast(transform.position, sphereRadious, transform.up * -1, out hit, sphereDistance, ground) 
        grounded=Grounded();  
            //Physics.Raycast(transform.position, Vector3.down, out hit, 0.525f, ground);

        if (grounded)
        {
            if (lastPaltform != newPlatform && !falling)
            {
                lastPaltform = newPlatform;
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
                if (currentVerticalDistance >= deathMultiplier*jumpHeight)
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
            //movementVector.y = movementVector.y + (Physics.gravity.y * gravityScale);
            //movementVector.y = transform.position.y;
            if (rb.velocity.y<0f && currentVerticalDistance == -1f)
            {
                currentVerticalDistance = transform.position.y;
            }
        }

        //rb.velocity = movementVector * Time.fixedDeltaTime;
        //rb.position += movementVector * Time.fixedDeltaTime;
        //rb.MovePosition(transform.position + movementVector * Time.fixedDeltaTime);
        transform.position += movementVector * Time.fixedDeltaTime;








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

    private bool Grounded()
    {
        bool res = false;
        int i = 0;
        while (i < hit.Length && !res)
        {
            res=Physics.Raycast(transform.position+raycastPositions[i], transform.up*-1, out hit[i], groundDistance, ground);
            if (res)
            {
                newPlatform = hit[i].transform;
            }
            i++;
        }

        return res;
    }

    public bool IsGrounded()
    {
        return grounded;
    }

    void OnCollisionEnter( Collision hit)
    {
        //print(hit.transform.name);
    }
}
