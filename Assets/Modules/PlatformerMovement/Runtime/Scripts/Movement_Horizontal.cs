using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement_Horizontal : MovementAffector
{
    [SerializeField] 
    private BaseInputProvider input;
    
    
    public override int OrderIndex => 2;

    public override void Run(float delta)
    {
        if (!movement.config.enableMoveInput)
            return;

        if (input is null)
            return;

        float targetSpeed = movement.config.runTopSpeed * input.Stick1.x;
        float diff = targetSpeed - movement.velocity.x;
        float accelRate = (Math.Abs(targetSpeed) > 0.01f)
            ? movement.config.runAccel
            : movement.config.runDeAccel;

        float move = diff * accelRate;
        movement.force += Vector2.right * move;
    }
}
