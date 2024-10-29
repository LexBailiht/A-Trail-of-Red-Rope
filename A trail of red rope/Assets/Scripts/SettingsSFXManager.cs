using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSFXManager : MonoBehaviour
{
    private AudioSource m_AudioSource;
    private float Volume;
    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void UpdateVolume()
    {
        Volume = GameManager.SFXVolumeOut;
        m_AudioSource.volume = Volume;
    }
}

