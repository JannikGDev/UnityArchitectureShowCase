using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderIntWrapper : MonoBehaviour
{
    [SerializeField] private IntReference value;

    private Slider slider;
    
    private void Awake()
    {
        slider = this.GetComponent<Slider>();
        slider.value = value.Value;
        slider.wholeNumbers = true;
    }

    private void IntValueChanged()
    {
        if(Mathf.Abs(slider.value - value.Value) > 0.01f)
            slider.value = value.Value;
    }

    void SliderValueChanged(float newVal)
    {
        if(Mathf.Abs(slider.value - value.Value) > 0.01f)
            value.Value = Mathf.RoundToInt(newVal);
    }

    private void OnEnable()
    {
        value.ValueChanged += IntValueChanged;
        slider.onValueChanged.AddListener(SliderValueChanged);
    }

    private void OnDisable()
    {
        value.ValueChanged -= IntValueChanged;
        slider.onValueChanged.RemoveListener(SliderValueChanged);
    }
}
