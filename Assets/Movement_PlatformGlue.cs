using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_PlatformGlue : MovementAffector
{
    [SerializeField] private LayerMask groundMask;

    private Vector3? groundPos;
    private Rigidbody2D body;
    
    public override void Run(float delta)
    {
        var halfw = movement.Size.x / 2f - movement.config.Skin;
        var halfh = movement.Size.y / 2f;
        var groundTolerance = movement.config.GroundTolerance;

        var hit = Physics2D.Raycast(movement.Position, Vector2.down, halfh + groundTolerance, groundMask);
        var rhit = Physics2D.Raycast(movement.Position + halfw * Vector2.right, Vector2.down, halfh + groundTolerance, groundMask);
        var lhit = Physics2D.Raycast(movement.Position + halfw * Vector2.left, Vector2.down, halfh + groundTolerance, groundMask);

        var nextBody = hit.collider?.attachedRigidbody ?? rhit.collider?.attachedRigidbody ?? lhit.collider?.attachedRigidbody;
        if (nextBody == null)
        {
            groundPos = null;
            return;
        }

        body = nextBody;

        if (groundPos == null || nextBody != body)
        {
            groundPos = body.position;
            return;
        }

        var diff = (body.position - groundPos).Value;

        if (diff.y > 0)
        {
            diff = new Vector3(diff.x, 0, diff.z);
        }
        groundPos = body.position;

        movement.Position += diff.V2();
    }

    public override int OrderIndex => 1;
}
