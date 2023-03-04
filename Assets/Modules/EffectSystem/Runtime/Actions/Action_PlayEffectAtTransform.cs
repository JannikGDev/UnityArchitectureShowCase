using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Action_PlayEffectAtTransform : BaseAction
{
    [SerializeField] 
    private EffectObject effect;

    [SerializeField] 
    private Vector3 offset;

    [SerializeField] 
    private Transform targetTransform;
    
    
    public override void X_PerformAction()
    {
        PlayEffectAtTransform(targetTransform, offset);
    }

    public void PlayEffectAtTransform(Transform transform, Vector3 offset = default)
    {
        var effectService = Game.Services.GetService<IEffectService>();
        effectService.CreateEffectAtTransform(effect,transform,offset);
    }
}
