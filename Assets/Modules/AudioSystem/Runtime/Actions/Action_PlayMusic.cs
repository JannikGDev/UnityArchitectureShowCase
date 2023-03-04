using System.Collections;
using System.Collections.Generic;
using Modules.AudioSystem.Runtime;
using UnityEngine;

public class Action_PlayMusic : BaseAction
{
    [SerializeField]
    private MusicObject music;
    
    public override void X_PerformAction()
    {
        IAudioService audio = Game.Services.GetService<IAudioService>();
        audio.PlayMusic(music);
    }
}
