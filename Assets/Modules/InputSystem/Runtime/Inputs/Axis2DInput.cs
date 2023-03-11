using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis2DInput
{
    public Vector2 V2;

    public float x
    {
        get => V2.x;
        set => V2.x = value;
    }
    
    public float y
    {
        get => V2.y;
        set => V2.y = value;
    }
}