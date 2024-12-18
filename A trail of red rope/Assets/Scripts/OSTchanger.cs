using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSTchanger : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip ShadyDealings;
    public AudioClip GiovanniTheme;
    public AudioClip selectedOST;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = null;
    }

    public void PlayMusic(string music)
    {
        if (music == "shadydealings")
        {
            selectedOST = ShadyDealings;
        }
        if (music == "giovannitheme")
        {
            selectedOST = GiovanniTheme;
        }
        AudioSource.clip = selectedOST;
        AudioSource.Play();
    }

    public void LoadMusic()
    {
        AudioSource.clip = selectedOST;
       // AudioSource.Play();
    }
}
