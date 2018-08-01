using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour {

    PlayerController parent;

    public void SetParent(PlayerController _parent)
    {
        parent = _parent;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Interactive") && other.GetComponent<IObject>()!=null)
        {
            parent.interactableObject = other.GetComponent<InteractiveObject>();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (parent.interactableObject!=null && other.GetComponent<IObject>()==parent.interactableObject.GetComponent<IObject>())
        {
            parent.interactableObject = null;
            print(other.name);
        }
    }
}
