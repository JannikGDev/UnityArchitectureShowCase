using System;
using UnityEngine;

/// <summary>
/// Vector3Reference Class.
/// </summary>
[Serializable]
public class FloatReference : Reference<float, FloatVariable>
{
    public FloatReference(float value) : base(value) { }
    public FloatReference() { }
}