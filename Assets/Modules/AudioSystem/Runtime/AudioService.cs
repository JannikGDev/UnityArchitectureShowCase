using Modules.Core.ServiceLocator;
using UnityEngine;

namespace Modules.AudioSystem.Runtime
{
    public class AudioService : BaseService<IAudioService>, IAudioService
    {
        private AudioSource activeMusic;
        
        public void PlaySound(SoundObject sound)
        {
            sound.Play();
        }

        public void PlayMusic(MusicObject music)
        {
            StopMusic();
            activeMusic = music.Play();
        }

        public void StopMusic()
        {
            if (activeMusic == null)
                return;
            
            activeMusic.Stop();
            Destroy(activeMusic.gameObject);
            activeMusic = null;
        }
    }
}