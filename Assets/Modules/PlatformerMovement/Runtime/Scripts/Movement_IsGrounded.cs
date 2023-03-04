using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement_IsGrounded : MovementAffector
{
    [SerializeField] private LayerMask groundMask;

    public override int OrderIndex => 1;
    
    public override void Run(float delta)
    {
        var halfw = movement.Size.x / 2f - movement.config.Skin;
        var halfh = movement.Size.y / 2f;
        var groundTolerance = movement.config.GroundTolerance;

        var hit = Physics2D.Raycast(movement.Position, Vector2.down, halfh + groundTolerance, groundMask);
        var rhit = Physics2D.Raycast(movement.Position + halfw * Vector2.right, Vector2.down, halfh + groundTolerance, groundMask);
        var lhit = Physics2D.Raycast(movement.Position + halfw * Vector2.left, Vector2.down, halfh + groundTolerance, groundMask);
        movement.IsGrounded = hit.collider is not null || rhit.collider is not null || lhit.collider is not null;
    }
    
    private void OnDrawGizmos()
    {
        var halfw = movement.Size.x / 2f - movement.config.Skin;
        var halfh = movement.Size.y / 2f;
        var groundTolerance = movement.config.GroundTolerance;
        
        var start = movement.Position;
        var end = movement.Position + Vector2.down * (halfh + groundTolerance);
        
        Gizmos.DrawLine(start, end);
        Gizmos.DrawLine(start + Vector2.right * halfw, end + Vector2.right * halfw);
        Gizmos.DrawLine(start + Vector2.left * halfw, end + Vector2.left * halfw);
    }
}
