using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObject{
    bool canInteract
    {
        get;
        set;
    }
    bool glowOn
    {
        get;
        set;
    }
    void Activate(int PlayerId, bool deactivate = false);
}
