using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[ExecuteInEditMode]
public class Movement_Patrol : MovementAffector
{
    [SerializeField]
    private Transform[] PatrolPoints;

    private Vector3[] Points;
    
    private int currentPoint = 0;

    [SerializeField]
    private float speed = 1;

    public override void Run(float delta)
    {
        if (Points.Length == 0)
            return;
        
        var target = Points[currentPoint];
        var diff = target.V2() - this.movement.Position;
        
        if (speed*speed*Time.fixedDeltaTime > diff.sqrMagnitude)
        { //Reached Target
            currentPoint++;
            if (currentPoint >= Points.Length)
                currentPoint = 0;
        }
        
        movement.velocityOverwrite = diff.normalized * speed;
    }

    public override int OrderIndex => 1;

    private void OnDrawGizmos()
    {
        RecalculatePatrolPoints();
        
        if (Points.Length == 0)
            return;
        
        var lastPoint = Points[^1];
        foreach (var p in Points)
        {
            Gizmos.DrawLine(lastPoint, p);
            DrawTriangle(lastPoint+((p-lastPoint)/2),Vector3.SignedAngle(Vector3.up, (p-lastPoint),Vector3.forward));
            Gizmos.DrawWireCube(p, movement.Size);
            lastPoint = p;
        }
    }

    private void DrawTriangle(Vector3 position, float angleDeg, float size = 0.3f)
    {
        var rotation = Quaternion.AngleAxis(angleDeg, Vector3.forward);
        
        var pointA = position + rotation * Vector3.up * size;
        var pointB = position + rotation * Vector3.right * size/2;
        var pointC = position + rotation * Vector3.left * size/2;
        
        Gizmos.DrawLine(pointA, pointB);
        Gizmos.DrawLine(pointB, pointC);
        Gizmos.DrawLine(pointC, pointA);
    }
    
    private void Start()
    {
        RecalculatePatrolPoints();
    }

    private void RecalculatePatrolPoints()
    {
        Points = PatrolPoints.Select(p => p.position).ToArray();
    }
}
