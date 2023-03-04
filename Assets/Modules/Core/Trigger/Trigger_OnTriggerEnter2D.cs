using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Trigger_OnTriggerEnter2D : BaseTrigger
{
    [SerializeField]
    private bool FilterByTag;

    [SerializeField]
    private string tag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (FilterByTag && !other.gameObject.CompareTag(tag))
            return;
        
        this.Trigger();
    }
}
