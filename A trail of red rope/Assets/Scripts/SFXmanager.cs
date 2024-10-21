using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip settingsopen;
    public AudioClip cancel;
    private AudioClip selectedSFX;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = null;
    }

    public void PlaySoundEffect(string sfx)
    {
        if (sfx == "shadydealings")
        {
            selectedSFX = settingsopen;
        }
        if (sfx == "giovannitheme")
        {
            selectedSFX = cancel;
        }
        AudioSource.clip = selectedSFX;
        AudioSource.Play();
    }
}
