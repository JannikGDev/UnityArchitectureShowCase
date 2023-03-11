using System;
using System.Collections;
using System.Collections.Generic;
using Modules.Core.ServiceLocator;
using UnityEngine;

public class GlobalTimerService : BaseService<IGlobalTimerService>, IGlobalTimerService
{
    [SerializeField]
    public float DayTime;
    
    [SerializeField]
    public int DayOfMonth = 1;
    
    [SerializeField]
    public int Month = 1;

    private void Update()
    {
        DayTime += Time.deltaTime * 0.1f;
        if (DayTime > 1.0)
        {
            DayTime = 0;
            DayOfMonth += 1;
        }

        if (DayOfMonth > 31)
        {
            Month += 1;
            DayOfMonth = 1;
        }

        if (Month > 12)
        {
            Month = 0;
        }
    }

    public float GetDayTime()
    {
        return DayTime;
    }

    public int GetDayOfMonth() 
    {
        return DayOfMonth;
    }

    public int GetMonth()
    {
        return Month;
    }
}
