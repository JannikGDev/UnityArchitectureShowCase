using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class SliderFloatWrapper : MonoBehaviour
{
    [SerializeField] private FloatReference value;

    private Slider slider;
    
    private void Awake()
    {
        slider = this.GetComponent<Slider>();
        slider.value = value.Value;
        slider.wholeNumbers = false;
    }

    private void FloatValueChanged()
    {
        if(Mathf.Abs(slider.value - value.Value) > 0.00001f)
            slider.value = value.Value;
    }

    void SliderValueChanged(float newVal)
    {
        if(Mathf.Abs(slider.value - value.Value) > 0.00001f)
            value.Value = newVal;
    }

    private void OnEnable()
    {
        value.ValueChanged += FloatValueChanged;
        slider.onValueChanged.AddListener(SliderValueChanged);
    }

    private void OnDisable()
    {
        value.ValueChanged -= FloatValueChanged;
        slider.onValueChanged.RemoveListener(SliderValueChanged);
    }
}
