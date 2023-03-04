using System;
using UnityEngine;

/// <summary>
/// Vector3Reference Class.
/// </summary>
[Serializable]
public class StringReference : Reference<string, StringVariable>
{
    public StringReference(string value) : base(value) { }
    public StringReference() { }
}
