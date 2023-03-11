using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A base class for creating input commands for the player or the AI.
/// </summary>
public class BaseInputProvider : MonoBehaviour
{
    /// <summary>
    /// A 2d axis input corresponding to the left analog stick of a typical xbox 360 controller
    /// </summary>
    public Axis2DInput Stick1 { get; protected set; } = new Axis2DInput();
    
    /// <summary>
    /// A 2d axis input corresponding to the right analog stick of a typical xbox 360 controller
    /// </summary>
    public Axis2DInput Stick2 { get; protected set; } = new Axis2DInput();

    /// <summary>
    /// An axis input corresponding to the left trigger (LT) of a typical xbox 360 controller
    /// </summary>
    public AxisInput LT { get; protected set; } = new AxisInput();

    /// <summary>
    /// An axis input corresponding to the right trigger (RT) of a typical xbox 360 controller
    /// </summary>
    public AxisInput RT { get; protected set; } = new AxisInput();

    /// <summary>
    /// A button input corresponding to the 'A' Button of a typical xbox 360 controller
    /// </summary>
    public ButtonInput A { get; protected set; } = new ButtonInput();
    
    /// <summary>
    /// A button input corresponding to the 'B' Button of a typical xbox 360 controller
    /// </summary>
    public ButtonInput B { get; protected set; } = new ButtonInput();
    
    /// <summary>
    /// A button input corresponding to the 'X' Button of a typical xbox 360 controller
    /// </summary>
    public ButtonInput X { get; protected set; } = new ButtonInput();
    
    /// <summary>
    /// A button input corresponding to the 'Y' Button of a typical xbox 360 controller
    /// </summary>
    public ButtonInput Y { get; protected set; } = new ButtonInput();
    
    /// <summary>
    /// A button input corresponding to the 'Start' Button of a typical xbox 360 controller
    /// </summary>
    public ButtonInput StartButton { get; protected set; } = new ButtonInput();
    
    /// <summary>
    /// A button input corresponding to the 'Back' Button of a typical xbox 360 controller
    /// </summary>
    public ButtonInput BackButton { get; protected set; } = new ButtonInput();
    
    /// <summary>
    /// A button input corresponding to the 'Right Bumper (RB)' Button of a typical xbox 360 controller
    /// </summary>
    public ButtonInput RB { get; protected set; } = new ButtonInput();
    
    /// <summary>
    /// A button input corresponding to the 'Left Bumper (LB)' Button of a typical xbox 360 controller
    /// </summary>
    public ButtonInput LB { get; protected set; } = new ButtonInput();
    
    /// <summary>
    /// A button input corresponding to pressing the left analog stick of a typical xbox 360 controller
    /// </summary>
    public ButtonInput Stick1Press { get; protected set; } = new ButtonInput();
    
    /// <summary>
    /// A button input corresponding to pressing the right analog stick of a typical xbox 360 controller
    /// </summary>
    public ButtonInput Stick2Press { get; protected set; } = new ButtonInput();
    
    
    /// <summary>
    /// Presses the button for the given time, then releasing the button
    /// Any other manipulations of the button state will still work, but might lead to unexpected results
    /// </summary>
    /// <param name="button"></param>
    /// <param name="time"></param>
    /// <param name="useRealTime"></param>
    public void PressButton(ButtonInput button, float time, bool useRealTime)
    {
        StartCoroutine(pressButton(button, time, useRealTime));
    }

    private IEnumerator pressButton(ButtonInput button, float time, bool useRealTime)
    {
        button.isPressed = true;

        if(useRealTime)
            yield return new WaitForSecondsRealtime(time);
        else
            yield return new WaitForSeconds(time);

        button.isPressed = false;
    }
}
