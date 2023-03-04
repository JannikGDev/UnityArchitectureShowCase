using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementAffector : MonoBehaviour
{
    [SerializeField] protected MovementController movement;

    public abstract void Run(float delta);

    public abstract int OrderIndex { get; }

    private void OnEnable()
    {
        movement.RegisterAffector(this);
    }

    private void OnDisable()
    {
        movement.UnregisterAffector(this);
    }
}
