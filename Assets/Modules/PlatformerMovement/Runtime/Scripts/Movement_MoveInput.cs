using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Movement_MoveInput : MovementAffector
{
    [SerializeField] private KeyCode[] leftKeys;
    
    [SerializeField] private KeyCode[] rightKeys;
    
    [SerializeField] private KeyCode[] upKeys;
    
    [SerializeField] private KeyCode[] downKeys;
    
    public override int OrderIndex => 2;

    public override void Run(float delta)
    {
        if (!movement.config.enableMoveInput)
            return;
        
        Vector2 moveInput = Vector2.zero;
        
        if (leftKeys.Any(Input.GetKey))
        {
            moveInput += Vector2.left;
        }

        if (rightKeys.Any(Input.GetKey))
        {
            moveInput += Vector2.right;
        }
        
        if (upKeys.Any(Input.GetKey))
        {
            moveInput += Vector2.up;
        }

        if (downKeys.Any(Input.GetKey))
        {
            moveInput += Vector2.down;
        }
        
        float targetSpeed = movement.config.runTopSpeed * moveInput.normalized.x;
        float diff = targetSpeed - movement.velocity.x;
        float accelRate = (Math.Abs(targetSpeed) > 0.01f)
            ? movement.config.runAccel
            : movement.config.runDeAccel;

        float move = diff * accelRate;
        //float move = Mathf.Pow(Mathf.Abs(diff)*accelRate, movement.config.runVelPower) * Mathf.Sign(diff);
        movement.force += Vector2.right * move;
    }
}
