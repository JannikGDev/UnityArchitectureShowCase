using System;
using UnityEngine;

/// <summary>
/// Vector3Reference Class.
/// </summary>
[Serializable]
public class BoolReference : Reference<bool, BoolVariable>
{
    public BoolReference(bool value) : base(value) { }
    public BoolReference() { }
}
