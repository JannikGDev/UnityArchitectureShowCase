using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_PlayEffect : BaseAction
{
    [SerializeField] 
    private EffectObject effect;

    [SerializeField] 
    private Vector3 position;
    
    [SerializeField] 
    private bool PlayAtObjectPosition;
    
    public override void X_PerformAction()
    {
        if (PlayAtObjectPosition)
            PlayEffectAtPos(gameObject.transform.position +position);
        else
            PlayEffectAtPos(position);
    }

    public void PlayEffectAtPos(Vector3 position = default)
    {
        var effectService = Game.Services.GetService<IEffectService>();
        effectService.CreateEffectAtPos(effect,position);
    }
}
