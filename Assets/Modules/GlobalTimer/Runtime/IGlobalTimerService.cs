using System.Collections;
using System.Collections.Generic;
using Modules.Core.ServiceLocator;
using UnityEngine;

public interface IGlobalTimerService : IGameService
{
    /// <summary>
    /// Returns a value between 0 and 1, where 0 is the start of the day and 1 is the end
    /// </summary>
    /// <returns></returns>
    public float GetDayTime();

    public int GetDayOfMonth();

    public int GetMonth();
}


public class DummyGlobalTimerService : IGlobalTimerService
{
    public float GetDayTime()
    {
        return 0;
    }

    public int GetDayOfMonth()
    {
        return 1;
    }

    public int GetMonth()
    {
        return 1;
    }
}