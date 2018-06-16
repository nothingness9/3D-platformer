using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public PlayerController Player;
	void Start () {

        Cursor.lockState = CursorLockMode.Locked; 
	}
    //set everything here first
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
