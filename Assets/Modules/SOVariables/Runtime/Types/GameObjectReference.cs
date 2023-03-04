using System;
using UnityEngine;

/// <summary>
/// Vector3Reference Class.
/// </summary>
[Serializable]
public class GameObjectReference : Reference<GameObject, GameObjectVariable>
{
    public GameObjectReference(GameObject value) : base(value) { }
    public GameObjectReference() { }
}
