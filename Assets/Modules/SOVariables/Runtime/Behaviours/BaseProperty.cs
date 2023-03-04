using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseProperty<T> : MonoBehaviour
{
    [SerializeField] 
    protected UnityEvent<T> OnOutput;

    [SerializeField] 
    protected UnityEvent<string> OnOutputAsText;

    [SerializeField] 
    public bool outputEachFrame;

    private void Awake()
    {
        OnOutput.AddListener(val => OnOutputAsText.Invoke(val.ToString()));
    }

    private void OnEnable()
    {
        Activate();
    }

    private void OnDisable()
    {
        Deactivate();
    }

    protected abstract void Activate();

    protected abstract void Deactivate();
    
    private void Start()
    {
        UpdateOutput();
    }
    
    private void Update()
    {
        if(outputEachFrame)
            UpdateOutput();
    }

    protected abstract void UpdateOutput();
}
