using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Movement_Jump : MovementAffector
{
    public override int OrderIndex => 2;

    [SerializeField] private BaseInputProvider input;
    
    private bool isJumping;
    //private bool jumpInputReleased;

    //private float lastGroundedTime;
    //private float lastJumpTime;
    
    public override void Run(float delta)
    {
        if (!movement.config.enableJump)
            return;

        if (isJumping)
        {
            whileJumping();
            return;
        }

        if (!movement.IsGrounded)
            return;

        if(movement.force.y > 0.01f)
            return;

        if (!input.A.isPressed)
            return;

        Jump();
    }

    private void Jump()
    {
        movement.force = Vector2.up * (movement.config.jumpForce);

        isJumping = true;
    }

    private void whileJumping()
    {
        if (!input.A.isPressed)
        {
            //jumpInputReleased = true;
            isJumping = false;
            return;
        }
        //TODO: Make jump last longer when holding key
        //movement.force = Vector2.up * (movement.config.jumpForce);
    }

   
}
