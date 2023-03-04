using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_DestroyObject : BaseAction
{
    [SerializeField] private GameObject target;
    
    public override void X_PerformAction()
    {
        GameObject.Destroy(target);
    }
}
