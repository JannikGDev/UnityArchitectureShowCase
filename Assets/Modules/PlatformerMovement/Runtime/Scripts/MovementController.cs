using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D target;

    [SerializeField] public Movement_Config config;
    
    private List<MovementAffector> affectors = new List<MovementAffector>();
    
    public bool IsGrounded;

    public Vector2 Size => target.GetComponent<Collider2D>().bounds.size;

    public Vector2 Position
    {
        get => target.position;
        set => target.position = value;
    }
    
    public Vector2 force;

    public Vector2 velocity => target.velocity;

    public Vector2? velocityOverwrite = null;

    private void FixedUpdate()
    {
        this.force = Vector2.zero;
        
        foreach (var affector in affectors)
        {
            affector.Run(Time.fixedDeltaTime);
        }
        
        if (velocityOverwrite != null)
        {
            target.velocity = velocityOverwrite.Value;
            return;
        }
        
        target.AddForce(force, ForceMode2D.Impulse);
    }


    public void RegisterAffector(MovementAffector affector)
    {
        var preCount = affectors.Count(af => af.OrderIndex < affector.OrderIndex);
        affectors.Insert(preCount,affector);
    }

    public void UnregisterAffector(MovementAffector affector)
    {
        affectors.Remove(affector);
    }
}
