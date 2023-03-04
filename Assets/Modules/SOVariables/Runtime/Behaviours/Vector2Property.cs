using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Vector2Property : BaseProperty<Vector2>
{
    [SerializeField] private Vector2Reference reference;
    
    protected override void Activate()
    {
        if (reference != null && !reference.UseConstant)
                    reference.ValueChanged += UpdateOutput;
    }
    
    protected override void Deactivate()
    {
        if (reference != null && !reference.UseConstant)
            reference.ValueChanged -= UpdateOutput;
    }

    protected override void UpdateOutput()
    {
        if (reference == null || reference.Value == null)
            throw new Exception("Reference is not set!");

        OnOutput.Invoke(reference.Value);
    }
    
    public void WriteValue(Vector2 value)
    {
        reference.Value = value;
    }
    
    public Vector2 ReadValue()
    {
        if (reference == null || reference.Value == null)
            throw new Exception("Reference is not set!");

        return reference.Value;
    }
}
