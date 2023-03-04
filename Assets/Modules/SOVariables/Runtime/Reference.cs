using System;
using UnityEngine;

/// <summary>
/// Reference Class.
/// </summary>
[Serializable]
public abstract class Reference
{
}

/// <summary>
/// Reference Class.
/// </summary>
[Serializable]
public class Reference<T, G> : Reference, IObservable where G : Variable<T>
{
    public bool UseConstant = true;

    public T ConstantValue;

    public G Variable;
    
    public event Action ValueChanged
    {
        add
        {
            if (Variable == null || UseConstant)
                return;

            Variable.ValueChanged += value;
        }
        remove
        {
            if (Variable == null || UseConstant)
                return;
            
            Variable.ValueChanged -= value;
        }
    }
    
    public Reference() { }
    public Reference(T value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public T Value
    {
        get { return UseConstant ? ConstantValue : (Variable == null ? default(T) : Variable.Value); }
        set
        {
            if (this.Value != null && this.Value.Equals(value))
                return;
            
            if (UseConstant)
                ConstantValue = value;
            else if (Variable != null)
            {
                Variable.Value = value;
                Debug.LogWarning("Trying to write to SOVariable that was not set");
            }
                
        }
    }

    public static implicit operator T(Reference<T, G> Reference)
    {
        return Reference.Value;
    }

    public static implicit operator Reference<T, G>(T Value)
    {
        return new Reference<T, G>(Value);
    }
}