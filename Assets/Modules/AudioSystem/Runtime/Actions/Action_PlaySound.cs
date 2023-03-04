using System.Collections;
using System.Collections.Generic;
using Modules.AudioSystem.Runtime;
using UnityEngine;

public class Action_PlaySound : BaseAction
{
    [SerializeField]
    private SoundObject sound;
    
    public override void X_PerformAction()
    {
        IAudioService audio = Game.Services.GetService<IAudioService>();
        audio.PlaySound(sound);
    }
}
