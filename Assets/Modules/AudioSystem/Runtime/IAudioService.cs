using Modules.Core.ServiceLocator;

namespace Modules.AudioSystem.Runtime
{
    public interface IAudioService : IGameService
    {
        public void PlaySound(SoundObject sound);

        public void PlayMusic(MusicObject music);
        public void StopMusic();

        public static IAudioService Dummy => new DummyAudioService();
    }
    
    
    public class DummyAudioService : IAudioService
    {
        public void PlaySound(SoundObject sound) { }

        public void PlayMusic(MusicObject music) { }

        public void StopMusic() { }
    }
}