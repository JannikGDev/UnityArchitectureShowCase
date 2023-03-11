using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SoundEffect", menuName = "Systems/Audio/SoundEffect")]
public class SoundObject : ScriptableObject
{
    public AudioClip clip;

    public float Volume;

    public float Pitch;
    
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
        source.volume = Volume;
        source.pitch = Pitch;

        source.Play();
        
        Destroy(source.gameObject, source.clip.length/source.pitch);
        
        return source;
    }
}
