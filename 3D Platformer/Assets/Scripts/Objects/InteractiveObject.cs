using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IObject {
    protected bool _canInteract=true;
    protected bool _glowOn=false;
    public bool animated;

    /////////// Animation variables
    // thinked for objects that behave like buttons
    //code: 0 Idle
    //      1 Starting
    //      2 Returning to idle
    protected int animationState;
    public float[] animationTimes;
    public Animator anim;
    protected Coroutine animationRutine; 

    public GameObject[] objects2Activate;

    // Use this for initialization
    void Start () {
        animated = (anim!=null) ?true:false;
        animationState = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Activate(int playerId, bool deactivate=false)
    {
        if (animationRutine!=null)
        {
            StopCoroutine(animationRutine);
        }
        animationState = (!deactivate) ?1:2;
        print("State: " + animationState);
        animationRutine = StartCoroutine(ActivateRoutine());
    }

    public virtual IEnumerator ActivateRoutine()
    {
        if (anim != null)
        {
            anim.SetInteger("State",animationState);
        }
         yield return new WaitForSeconds(animationTimes[animationState]);
        switch (animationState)
        {
            case 1:
                _glowOn = false;
                canInteract = false;
                foreach (GameObject g in objects2Activate)
                {
                    g.SendMessage("Activate");
                }
                break;
            case 2:
                canInteract = true;
                animationState = 0;
                anim.SetInteger("State", animationState);

                break;
        }
    }

    /////////Getters & setters

    public bool canInteract
    {
        get
        {
            return _canInteract;
        }
        set
        {
            _canInteract = value;
        }
    }

    public bool glowOn
    {
        get
        {
            return _glowOn;
        }
        set
        {
            _glowOn = value;
        }
    }
}
