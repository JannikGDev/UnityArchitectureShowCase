using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_SpawnPrefab : BaseAction
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    Vector3 position = Vector3.zero;

    [SerializeField]
    Quaternion rotation = Quaternion.identity;

    [SerializeField]
    bool SpawnRelativeToCreator = true;

    [SerializeField]
    Transform parent = null;
    
    public void SpawnPrefab(GameObject prefab)
    {
        if(parent != null)
        {
            if (SpawnRelativeToCreator)
                Instantiate(prefab, position + this.transform.position, rotation, parent);
            else
                Instantiate(prefab, position, rotation, parent);
        }

        if(SpawnRelativeToCreator)
            Instantiate(prefab, position + this.transform.position, rotation);
        else
            Instantiate(prefab, position, rotation);
    }

    public override void X_PerformAction()
    {
        SpawnPrefab(null);
    }
}
