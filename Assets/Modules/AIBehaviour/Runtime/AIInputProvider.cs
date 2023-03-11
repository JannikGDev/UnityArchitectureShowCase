using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputProvider : BaseInputProvider
{
    [SerializeField] private Transform target;
    
    public void Update()
    {
        var pos = this.transform.position;
        var targetPos = target.position;
        
        
        var diff = targetPos - pos;

        this.Stick1.V2 = diff.normalized;

        if (diff.y > 0.5f && !this.A.isPressed)
        {
            this.PressButton(this.A, 0.1f, false);
        }
    }
}
