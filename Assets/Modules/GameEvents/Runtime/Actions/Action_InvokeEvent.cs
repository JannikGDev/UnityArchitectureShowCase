using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_InvokeEvent : BaseAction
{
    [SerializeField] private GameEvent gameEvent;
    
    public override void X_PerformAction()
    {
        gameEvent.Invoke();
    }
}
