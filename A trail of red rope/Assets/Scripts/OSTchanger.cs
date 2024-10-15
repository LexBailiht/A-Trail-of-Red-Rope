using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSTchanger : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip ShadyDealings;
    public AudioClip GiovanniTheme;
    private AudioClip selectedOST;
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
            AudioSource.volume = 1f;
        }
        if (music == "giovannitheme")
        {
            selectedOST = GiovanniTheme;
            AudioSource.volume = 0.6f;
        }
        AudioSource.clip = selectedOST;
        AudioSource.Play();
    }

}
