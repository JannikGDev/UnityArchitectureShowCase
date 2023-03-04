using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger_OnEvent : BaseTrigger, IGameEventListener
{
    [SerializeField] private GameEvent gameEvent;
    
    public void OnEnable()
    {
        gameEvent.Register(this);
    }

    public void OnDisable()
    {
        gameEvent.Unregister(this);
    }

    public void OnGameEvent()
    {
        this.Trigger();
    }
}
