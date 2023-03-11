using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Dialog/DialogObject")]
public class DialogObject : ScriptableObject
{
    [SerializeField]
    private List<DialogPart> parts;
    
    [SerializeField]
    private int currentPart;

    public DialogPart Part => parts[currentPart];

    public void OnEnable()
    {
        this.Reset();
    }

    public void Reset()
    {
        currentPart = 0;
    }

    /// <summary>
    /// Moves to the next part of the dialogue
    /// </summary>
    /// <returns>true if the next part was loaded, false when there is no next part</returns>
    public bool NextPart()
    {
        if (parts.Count <= currentPart + 1)
            return false;
        
        currentPart++;
        return true;
    }
}

[Serializable]
public class DialogPart
{
    [Tooltip("Only used internally")]
    public string Name;
    
    [Multiline]
    public string Text;

    public bool LeftActive;
    public string LeftName;
    public Sprite LeftAvatar;

    public bool RightActive;
    public string RightName;
    public Sprite RightAvatar;

    public override string ToString()
    {
        return Name;
    }
}
