using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;	

    [SerializeField] private AudioSource musicSource, effectSource;

    void Awake() 
    {
            Instance = this;
    
    }

    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);

    }

    public void ChangeVolume(float value) 
    {
        AudioListener.volume = value;
    }

    public void ToggleSFX()
    {
        effectSource.mute = !effectSource.mute;
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void Stop()
    {
        musicSource.Stop();
        effectSource.Stop();
    }

  
}
