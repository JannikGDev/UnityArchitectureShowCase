using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_OnGlobalTIme : BaseTrigger
{
    [SerializeField] 
    [Range(0,1)]
    private float TriggerTime;
    
    private void Update()
    {
        var globalTimer = Game.Services.GetService<IGlobalTimerService>();
        var currentTime = globalTimer.GetDayTime();

        if (currentTime > TriggerTime)
        {
            this.Trigger();
            this.Disarm();
        }
    }
}
