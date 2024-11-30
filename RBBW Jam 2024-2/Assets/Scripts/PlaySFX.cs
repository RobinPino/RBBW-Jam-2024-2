using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    [SerializeField] ObjectPool<AudioSource> AudioSourcePool;
    //[SerializeField] private SoundTypeSO soundType;

    private Dictionary<SoundTypeSO, ObjectPool<AudioSource>.PooledObject> mostRecentSources = new Dictionary<SoundTypeSO, ObjectPool<AudioSource>.PooledObject>();

    public void Play(SoundTypeSO soundType)
    {
        if (soundType.loop) { Stop(mostRecentSources[soundType]); }
        
        Sound sound = soundType.GetSound();
        if (sound == null)
        {
            return;
        }

        ObjectPool<AudioSource>.PooledObject source = AudioSourcePool.GetObject();
        mostRecentSources[soundType] = source;

        source.obj.clip = sound.clip;
        source.obj.volume = sound.volume;
        source.obj.loop = soundType.loop;
        source.obj.PlayScheduled(AudioSettings.dspTime + soundType.delay);
        if (!soundType.loop) { StartCoroutine(CheckFinishedPlaying(source)); }
    }

    public void StopMostRecent(SoundTypeSO soundType)
    {
        if (mostRecentSources.ContainsKey(soundType)) 
        {
            Stop(mostRecentSources[soundType]);
            mostRecentSources.Remove(soundType);
        }
    }

    private void Stop(ObjectPool<AudioSource>.PooledObject source)
    {
        source.obj.Stop();
        source.ReturnToPool();
    }

    IEnumerator CheckFinishedPlaying(ObjectPool<AudioSource>.PooledObject source)
    {
        while(source.obj.isPlaying)
        {
            print(source.obj.name + " is playing");
            float timeRemaining = source.obj.clip.length - source.obj.time;
            yield return new WaitForSeconds(timeRemaining);
        }

        Stop(source);
    }
}
