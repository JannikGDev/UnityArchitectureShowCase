using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableChanger : MonoBehaviour
{
    private float time;

    [SerializeField] private BoolReference Enabled;
    [SerializeField] private BoolReference boolVar;
    [SerializeField] private IntReference intVar;
    [SerializeField] private FloatReference floatVar;
    [SerializeField] private DoubleReference doubleVar;
    [SerializeField] private StringReference stringVar;
    [SerializeField] private GameObjectReference GOVar;
    [SerializeField] private Vector2Reference V2Var;
    [SerializeField] private Vector3Reference V3Var;
    
    // Update is called once per frame
    void Update()
    {
        if (!Enabled.Value)
            return;
        
        time += Time.deltaTime;

        boolVar.Value = (int)time % 2 == 0;
        intVar.Value = (int)time;
        floatVar.Value = time;
        doubleVar.Value = time;
        stringVar.Value = $"{(int)time} seconds";
        GOVar.Value = (int)time % 2 == 0 ? this.gameObject : this.transform.parent.gameObject;

        V2Var.Value = new Vector2(-Mathf.Sin(time), -Mathf.Cos(time));
        V3Var.Value = new Vector3(Mathf.Sin(time), Mathf.Cos(time), Mathf.Tan(time));
    }
}
