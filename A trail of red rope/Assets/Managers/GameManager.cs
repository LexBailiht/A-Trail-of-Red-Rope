using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int DialogueNumber = 0;
    public int LastDialogueNumber = 0;
    public int TalkDialogueNumber = 0;
    public int TalkLastDialogueNumber = 0;
    public int ScrutinizeDialogueNumber = 0;
    public int ScrutinizeLastDialogueNumber = 0;
    public int InvestigateDialogueNumber = 0;
    public int InvestigateLastDialogueNumber = 0;
    public int MoveDialogueNumber = 0;
    public int MoveLastDialogueNumber = 0;
    public GameObject SettingsMenu;
    public Button NotebookButton;
    public Animator settingsanimator;
    public bool SettingsState = false;
    public AudioSource AudioSource;
    public AudioSource SFXAudioSource;
    public float MasterVolume = 0.5f;
    public Slider MasterVolumeSlider;
    public float MusicVolume = 0.5f;
    public float MusicVolumeOut = 0.5f;
    public Slider MusicVolumeSlider;
    public float SFXVolume = 0.125f;
    public float SFXVolumeOut = 0.125f;
    public Slider SFXVolumeSlider;

    private int QTEResult;
    public GameObject TalkButton;

    //public TextMeshProUGUI NotebookText;

    void Start()
    {

    }

    public void NextLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToggleSettings()
    {
        if (SettingsState == false)
        {
            SettingsState = true;
            SFXAudioSource.GetComponent<SFXmanager>().PlaySoundEffect("settingsopen");
            settingsanimator.SetBool("IsOpen", true);
            Time.timeScale = 0f;
            NotebookButton.enabled = false;
            AudioSource.Pause();
           // SettingsMenu.SetActive(true);
        } else
        {
            SettingsState = false;
            settingsanimator.SetBool("IsOpen", false);
            Time.timeScale = 1f;
            NotebookButton.enabled = true;
            SFXAudioSource.GetComponent<SFXmanager>().PlaySoundEffect("cancel");
            AudioSource.Play();
            //SettingsMenu.SetActive(false);
        }
    }

    public void UpdateMasterVolume()
    {
        MasterVolume = MasterVolumeSlider.value;
        AudioSource.volume = MusicVolume * MasterVolume;
        SFXAudioSource.volume = SFXVolume * MasterVolume;
        SFXVolumeOut = SFXAudioSource.volume;
    }
    public void UpdateMusicVolume()
    {
        MusicVolume = MusicVolumeSlider.value;
        AudioSource.volume = MusicVolume * MasterVolume;
    }
    public void UpdateSFXVolume()
    {
        SFXVolume = SFXVolumeSlider.value;
        SFXAudioSource.volume = SFXVolume * MasterVolume;
        SFXVolumeOut = SFXAudioSource.volume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettings();
        }
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void UpdateGameState()
    {
        if (TalkLastDialogueNumber == 1)
        {
            TalkDialogueNumber = 1;
        }

        QTEResult = gameObject.GetComponent<QTEbehavior>().PassQTE;
        if (QTEResult == 1 && TalkLastDialogueNumber == 2)
        {
            TalkDialogueNumber = 2;
            TalkButton.GetComponent<DialogueTrigger>().TriggerDialogue();
            gameObject.GetComponent<QTEbehavior>().PassQTE = 0;
        }
        if (QTEResult == 2 && TalkLastDialogueNumber == 2)
        {
            TalkDialogueNumber = 3;
            TalkButton.GetComponent<DialogueTrigger>().TriggerDialogue();
            gameObject.GetComponent<QTEbehavior>().PassQTE = 0;
        }
    }

    public void EndDemo()
    {
        SceneManager.LoadScene(sceneName: "DemoEnd");
    }

}
