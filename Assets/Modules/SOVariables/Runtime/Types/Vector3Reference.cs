using System;
using UnityEngine;

/// <summary>
/// Vector3Reference Class.
/// </summary>
[Serializable]
public class Vector3Reference : Reference<Vector3, Vector3Variable>
{
    public Vector3Reference(Vector3 value) : base(value) { }
    public Vector3Reference() { }
}

