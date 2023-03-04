using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTrigger;

    protected bool armed { get; private set; } = true;
    
    public void Disarm()
    {
        armed = false;
    }

    public void Arm()
    {
        armed = true;
    }

    protected void Trigger()
    {
        if(armed)
            OnTrigger.Invoke();
    }
}
