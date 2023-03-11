using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBaseInputProvider : BaseInputProvider
{
    [SerializeField] private KeyCode[] leftKeys;
    
    [SerializeField] private KeyCode[] rightKeys;
    
    [SerializeField] private KeyCode[] upKeys;
    
    [SerializeField] private KeyCode[] downKeys;
    
    [SerializeField] private KeyCode[] jumpKeys;
    
    void Update()
    {
        Vector2 axisInput = Vector2.zero;
        
        if (leftKeys.Any(Input.GetKey))
        {
            axisInput += Vector2.left;
        }

        if (rightKeys.Any(Input.GetKey))
        {
            axisInput += Vector2.right;
        }
        
        if (upKeys.Any(Input.GetKey))
        {
            axisInput += Vector2.up;
        }

        if (downKeys.Any(Input.GetKey))
        {
            axisInput += Vector2.down;
        }

        axisInput = axisInput.normalized;

        this.Stick1.V2 = axisInput;
        this.A.isPressed = jumpKeys.Any(Input.GetKey);
    }
}
