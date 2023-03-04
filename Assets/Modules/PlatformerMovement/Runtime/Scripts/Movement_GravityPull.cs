using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_GravityPull : MovementAffector
{
    [SerializeField] private float forceFactor = 1f;
    
    public override int OrderIndex => 2;

    public override void Run(float delta)
    {
        if (!movement.config.enableGravity)
            return;
        
        movement.force += movement.config.gravityDirection.normalized * (delta * movement.config.gravityForce * forceFactor);
    }

}
