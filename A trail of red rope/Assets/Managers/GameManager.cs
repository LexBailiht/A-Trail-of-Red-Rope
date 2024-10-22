using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    public Animator settingsanimator;
    public bool SettingsState = false;
    public AudioSource AudioSource;
    public AudioSource SFXAudioSource;

    private int QTEResult;
    public GameObject TalkButton;
    void Start()
    {
        
    }

    public void ToggleSettings()
    {
        if (SettingsState == false)
        {
            SettingsState = true;
            SFXAudioSource.GetComponent<SFXmanager>().PlaySoundEffect("settingsopen");
            settingsanimator.SetBool("IsOpen", true);
            Time.timeScale = 0f;
            AudioSource.Pause();
        } else
        {
            SettingsState = false;
            settingsanimator.SetBool("IsOpen", false);
            Time.timeScale = 1f;
            SFXAudioSource.GetComponent<SFXmanager>().PlaySoundEffect("cancel");
            AudioSource.Play();

        }
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

}
