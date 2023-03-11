using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput
{
    public event Action Pressed;
    
    public event Action Released;
    
    public bool isPressed
    {
        get => _isPressed;
        set
        {
            if (_isPressed == value)
                return;

            _isPressed = value;
            if(_isPressed)
                Pressed?.Invoke();
            else
                Released?.Invoke();
        }
    }
    private bool _isPressed;
}
