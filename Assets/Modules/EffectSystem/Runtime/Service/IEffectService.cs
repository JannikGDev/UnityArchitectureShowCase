using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffectService : IGameService
{
    public void CreateEffectAtPos(EffectObject effect, Vector3 pos);
    
    public void CreateEffectAtTransform(EffectObject effect, Transform transform, Vector3 offset = default);

    public void StopAllEffects();
}
