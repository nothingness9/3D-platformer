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

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        float horizontal = Input.GetAxis("Mouse X") *rotateSpeed;

        target.transform.Rotate(0f,horizontal,0f);

        pivot.Rotate(vertical, 0f, 0f);

        // move the camera based on the current rotation of the target 
        // and the original offset
        float deriseredYangle = target.transform.eulerAngles.y;
        float deriseredXangle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(deriseredXangle, deriseredYangle, 0f);

        transform.position = target.transform.position + rotation * offset;

        if (transform.position.y <= target.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
        }


        
        //transform.LookAt(target.transform);
	}
}
