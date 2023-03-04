using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleBoolWrapper : MonoBehaviour
{
    [SerializeField] private BoolReference value;

    private Toggle toggle;
    
    private void Awake()
    {
        toggle = this.GetComponent<Toggle>();
        toggle.isOn = value.Value;
    }

    private void BoolValueChanged()
    {
        if(toggle.isOn != value.Value)
            toggle.isOn = value.Value;
    }

    void ToggleValueChanged(bool newVal)
    {
        if(value.Value != newVal)
            value.Value = newVal;
    }

    private void OnEnable()
    {
        value.ValueChanged += BoolValueChanged;
        toggle.onValueChanged.AddListener(ToggleValueChanged);
    }

    private void OnDisable()
    {
        value.ValueChanged -= BoolValueChanged;
        toggle.onValueChanged.RemoveListener(ToggleValueChanged);
    }
}
