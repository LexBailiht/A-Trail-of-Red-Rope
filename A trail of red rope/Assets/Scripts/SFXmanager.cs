using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip settingsopen;
    public AudioClip cancel;
    public AudioClip blipmale;
    public AudioClip blipfemale;
    public AudioClip selectblip;
    public AudioClip selectedSFX;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = null;
    }

    public void PlaySoundEffect(string sfx)
    {
        if (sfx == "settingsopen")
        {
            selectedSFX = settingsopen;
        }
        if (sfx == "cancel")
        {
            selectedSFX = cancel;
        }
        if (sfx == "blipmale")
        {
            selectedSFX = blipmale;
        }
        if (sfx == "blipfemale")
        {
            selectedSFX = blipfemale;
        }
        if (sfx == "selectblip")
        {
            selectedSFX = blipfemale;
        }
        AudioSource.clip = selectedSFX;
        AudioSource.Play();
    }
}
