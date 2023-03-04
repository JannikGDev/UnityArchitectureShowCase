using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Effect/EffectObject")]
public class EffectObject : ScriptableObject
{
    [SerializeField] private GameObject prefab;

    public GameObject CreateAtPos(Vector3 position)
    {
        return Instantiate(prefab, position, Quaternion.identity);
    }
    
    public GameObject CreateAndStickToTransform(Transform transform, Vector3 offset = default)
    {
        var go = Instantiate(prefab, transform);
        go.transform.localPosition = offset;
        return go;
    }
    
}
