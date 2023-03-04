using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class IntProperty : BaseProperty<int>
{
    [SerializeField] private IntReference reference;
    
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
    
    public void WriteValue(int value)
    {
        reference.Value = value;
    }
    
    public int ReadValue()
    {
        if (reference == null || reference.Value == null)
            throw new Exception("Reference is not set!");

        return reference.Value;
    }
}
