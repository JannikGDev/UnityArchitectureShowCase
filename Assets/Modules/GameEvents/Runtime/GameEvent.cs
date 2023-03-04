using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Systems/GameEvents/Event")]
public class GameEvent : ScriptableObject
{
    private event Action _onEvent;

    public void Invoke()
    {
        _onEvent?.Invoke();
    }
    
    public void Register(IGameEventListener listener)
    {
        _onEvent += listener.OnGameEvent;
    }

    public void Unregister(IGameEventListener listener)
    {
        _onEvent -= listener.OnGameEvent;
    }
    
    
}
