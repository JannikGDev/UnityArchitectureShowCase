using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_DebugLog : BaseAction
{
    [SerializeField] private string message;

    public override void X_PerformAction()
    {
        Log(null);
    }

    public void Log(string message)
    {
        if (message == null)
            message = this.message;
        
        Debug.Log(message);
    }
}
