using System;
using UnityEngine;

/// <summary>
/// Vector3Reference Class.
/// </summary>
[Serializable]
public class DoubleReference : Reference<double, DoubleVariable>
{
    public DoubleReference(double value) : base(value) { }
    public DoubleReference() { }
}

