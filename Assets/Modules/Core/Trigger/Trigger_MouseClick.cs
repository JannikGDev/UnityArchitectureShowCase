using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Trigger_MouseClick : BaseTrigger
{
    [SerializeField] private UnityEvent<Vector2> OnMouseClickV2;
    [SerializeField] private UnityEvent<Vector3> OnMouseClickV3;

    private void Update()
    {
        if (!armed)
            return;
        
        if (!Input.GetMouseButtonDown((int) MouseButton.LeftMouse)) 
            return;

        var mousePos = Input.mousePosition;
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        var v3Pos = new Vector3(worldPos.x, worldPos.y, 0);
        OnMouseClickV2.Invoke(mousePos);
        OnMouseClickV3.Invoke(v3Pos);
        this.Trigger();
    }
}
