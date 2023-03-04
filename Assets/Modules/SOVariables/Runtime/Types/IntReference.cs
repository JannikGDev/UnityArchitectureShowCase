using System;
using UnityEngine;

/// <summary>
/// Vector3Reference Class.
/// </summary>
[Serializable]
public class IntReference : Reference<int, IntVariable>
{
    public IntReference(int value) : base(value) { }
    public IntReference() { }
}

