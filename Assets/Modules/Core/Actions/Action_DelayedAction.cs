using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Action_DelayedAction : BaseAction
{
    [SerializeField] 
    private UnityEvent NextActions;

    [SerializeField] 
    private float delayTime;

    [SerializeField] private bool useRealTime;
    
    public override void X_PerformAction()
    {
        StartCoroutine(DelayAction());
    }

    private IEnumerator DelayAction()
    {
        if(useRealTime)
            yield return new WaitForSecondsRealtime(delayTime);
        else
            yield return new WaitForSeconds(delayTime);
       
        NextActions.Invoke();
    }
}
