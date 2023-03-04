using System;
using UnityEngine;

/// <summary>
/// Variable Class.
/// </summary>
public class Variable<T> : ScriptableObject, IObservable
{
    [SerializeField]
    private T value;

    public T Value
    {
        get => value;
        set
        {
            if (this.value.Equals(value))
                return;
        
            //Debug.Log($"Changed: {this.value.ToString()} =>  {value.ToString()}");
            
            this.value = value;
            ValueChanged?.Invoke();
        }
    }
    
    public event Action ValueChanged;
    
    protected void OnEnable()
    {
        //Prevent object deletion when not used in active scene
        this.hideFlags |= HideFlags.DontUnloadUnusedAsset;
    }

    public void SetValue(Variable<T> value)
    {
        if (this.value.Equals(value.value))
            return;
        
        //Debug.Log($"Changed: {this.value.ToString()} =>  {value.ToString()}");
        
        this.value = value.value;
        ValueChanged?.Invoke();
    }
}
