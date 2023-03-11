using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimerTester : MonoBehaviour
{
    private float lastOutput = 0;
    
    // Start is called before the first frame update
    void Update()
    {
        if (Time.timeSinceLevelLoad - lastOutput > 2)
        {
            lastOutput = Time.timeSinceLevelLoad;

            var globalTimer = Game.Services.GetService<IGlobalTimerService>();
            var dayTime = globalTimer.GetDayTime();
            Debug.Log($"Daytime: {dayTime}"); 
        
            var dayOfMonth = globalTimer.GetDayOfMonth();
            Debug.Log($"DayOfMonth: {dayOfMonth}");
        
            var month = globalTimer.GetMonth();
            Debug.Log($"Month: {month}");
        }
    }
}
