using System;
using UnityEngine;

/// <summary>
/// Vector3Reference Class.
/// </summary>
[Serializable]
public class Vector2Reference : Reference<Vector2, Vector2Variable>
{
    public Vector2Reference(Vector2 value) : base(value) { }
    public Vector2Reference() { }
}
