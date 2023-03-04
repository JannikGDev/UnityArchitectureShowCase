using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SoundEffect", menuName = "Systems/Audio/SoundEffect")]
public class SoundObject : ScriptableObject
{
    public AudioClip clip;

    public AudioSource Play(AudioSource source = null)
    {
        if (clip == null)
        {
            return null;
        }

        if (source == null)
        {
            var obj = new GameObject("SoundEffect", typeof(AudioSource));
            source = obj.GetComponent<AudioSource>();
        }

        source.clip = clip;
        source.volume = 1;
        source.pitch = 1;

        source.Play();
        
        Destroy(source.gameObject, source.clip.length/source.pitch);
        
        return source;
    }
}
