using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Trigger_OnKeyInput : BaseTrigger
{

    [SerializeField] private KeyCode[] keys;

    [SerializeField] private bool triggerOnUp;

    void Update()
    {
        if (triggerOnUp)
        {
            if (keys.Any(Input.GetKeyUp))
            {
                this.Trigger();
            }
        }
        else
        {
            if (keys.Any(Input.GetKeyDown))
            {
                this.Trigger();
            }
        }
    }
}
