using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Move : BaseAction
{
    [SerializeField] private GameObject target;

    [SerializeField] private Vector3 movement;

    public override void X_PerformAction()
    {
        var objectToMove = target;
        if (objectToMove == null)
            objectToMove = this.gameObject;
        
        objectToMove.transform.position += movement;
    }
}
