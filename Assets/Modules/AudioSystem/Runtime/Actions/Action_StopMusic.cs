using Modules.AudioSystem.Runtime;

public class Action_StopMusic : BaseAction
{
    public override void X_PerformAction()
    {
        IAudioService audio = Game.Services.GetService<IAudioService>();
        audio.StopMusic();
    }
}
