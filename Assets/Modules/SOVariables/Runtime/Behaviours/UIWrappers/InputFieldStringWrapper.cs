using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_InputField))]
public class InputFieldStringWrapper : MonoBehaviour
{
   [SerializeField] private StringReference value;
   
   private TMP_InputField inputField;
   
   private void Awake()
   {
      inputField = this.GetComponent<TMP_InputField>();
      inputField.text = value.Value;
   }

   private void FloatValueChanged()
   {
      inputField.text = value.Value;
   }

   void InputFieldValueChanged(string text)
   {
      value.Value = text;
   }

   private void OnEnable()
   {
      value.ValueChanged += FloatValueChanged;
      inputField.onValueChanged.AddListener(InputFieldValueChanged);
   }

   private void OnDisable()
   {
      value.ValueChanged -= FloatValueChanged;
      inputField.onValueChanged.RemoveListener(InputFieldValueChanged);
   }
   
}
