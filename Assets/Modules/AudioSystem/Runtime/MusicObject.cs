using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Music", menuName = "Systems/Audio/Music")]
public class MusicObject : ScriptableObject
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
            var obj = new GameObject("MusicSource", typeof(AudioSource));
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
