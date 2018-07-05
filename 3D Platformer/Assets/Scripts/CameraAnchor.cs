using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchor : MonoBehaviour {

    public GameObject target;
    public Vector3 offset;

    public float rotateSpeed;


    public Transform pivot;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // get the x position of the mouse & rotate the target

        float vertical = Input.GetAxisRaw("Mouse Y") * rotateSpeed;
        float horizontal = Input.GetAxisRaw("Mouse X") *rotateSpeed;

        target.transform.Rotate(0f,horizontal,0f);

        
        if (!(vertical <= 0f && target.transform.position.y >= transform.position.y))
        {
            pivot.Rotate(vertical, 0f, 0f);
        }
        /*else
        {
            pivot.Rotate(0f, 0f, 0f);
        }*/

        // move the camera based on the current rotation of the target 
        // and the original offset
        float deriseredYangle = target.transform.eulerAngles.y;
        float deriseredXangle = pivot.eulerAngles.x;

        Quaternion rotation;
        /*
        if (GameManager.instance.Player.IsGrounded() && vertical <= 0f && target.transform.position.y >= transform.position.y)
        {
        }*/

        rotation = Quaternion.Euler(deriseredXangle, deriseredYangle, 0f);
        transform.position = target.transform.position + rotation * offset;
        /*
        if (Input.GetKeyDown(KeyCode.K))
        {
            print("Vertical"+vertical);
        }*/
        //transform.LookAt(target.transform);
    }
}
