using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Vector3Property : BaseProperty<Vector3>
{
    [SerializeField] private Vector3Reference reference;
    
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

    public void WriteValue(Vector3 value)
    {
        reference.Value = value;
    }
    
    public Vector3 ReadValue()
    {
        if (reference == null || reference.Value == null)
            throw new Exception("Reference is not set!");

        return reference.Value;
    }
}
