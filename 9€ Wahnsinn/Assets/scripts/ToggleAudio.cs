using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool toggleMusic;
    [SerializeField] private bool toggleSFX;

    public void Toggle()
    {
        if(toggleSFX) SoundManager.Instance.ToggleSFX();
        if(toggleMusic) SoundManager.Instance.ToggleMusic();
    }
}
