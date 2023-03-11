using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputVisualizer : MonoBehaviour
{
    [SerializeField] private BaseInputProvider input;

    [SerializeField] private GameObject A;
    [SerializeField] private GameObject B;
    [SerializeField] private GameObject X;
    [SerializeField] private GameObject Y;
    [SerializeField] private GameObject LB;
    [SerializeField] private GameObject RB;
    [SerializeField] private GameObject LeftStickPress;
    [SerializeField] private GameObject RightStickPress;
    [SerializeField] private GameObject StartButton;
    [SerializeField] private GameObject BackButton;
    
    [SerializeField] private GameObject DpadUp;
    [SerializeField] private GameObject DpadDown;
    [SerializeField] private GameObject DpadLeft;
    [SerializeField] private GameObject DpadRight;
    

    private void Update()
    {
        if (input is null)
            return;
    
        A.SetActive(input.A.isPressed);
        B.SetActive(input.B.isPressed);
        X.SetActive(input.X.isPressed);
        Y.SetActive(input.Y.isPressed);
        LB.SetActive(input.LB.isPressed);
        RB.SetActive(input.RB.isPressed);
        StartButton.SetActive(input.StartButton.isPressed);
        BackButton.SetActive(input.BackButton.isPressed);
        LeftStickPress.SetActive(input.Stick1Press.isPressed);
        RightStickPress.SetActive(input.Stick2Press.isPressed);
        
        DpadUp.SetActive(input.Stick1.y > 0);
        DpadDown.SetActive(input.Stick1.y < 0);
        DpadRight.SetActive(input.Stick1.x > 0);
        DpadLeft.SetActive(input.Stick1.x < 0);
    }
    
    
}
