using System;
using System.Collections;
using System.Collections.Generic;
using Modules.Core.ServiceLocator;
using UnityEngine;

public class EffectService : BaseService<IEffectService>, IEffectService
{
    private List<GameObject> activeEffects;

    public void CreateEffectAtPos(EffectObject effect, Vector3 pos)
    {
        effect.CreateAtPos(pos);
    }

    public void CreateEffectAtTransform(EffectObject effect, Transform transform, Vector3 offset = default)
    {
        effect.CreateAndStickToTransform(transform, offset);
    }

    public void StopAllEffects()
    {
        foreach (var effect in activeEffects)
        {
            GameObject.Destroy(gameObject);
        }
        
        activeEffects.Clear();
    }
}
