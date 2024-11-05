using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotepadTrigger : MonoBehaviour
{
    public GameObject Paper;
    public TMP_InputField InputField;
    private bool paperON;
    public string NotebookText;
    public bool hasClicked = false;
    public Animator animator;
    public AudioSource SFXAudioSource;

   public void Onclick()
    {
        if (paperON == false && hasClicked == false) 
        {
           StartCoroutine(ButtonReset());
            paperON = true;
            animator.SetBool("IsOpen", true);
            SFXAudioSource.GetComponent<SFXmanager>().PlaySoundEffect("settingsopen");
        }
        if (paperON == true && hasClicked == false)
        {
            CloseNotebook();
        }
    }

    public void CloseNotebook()
    {
        if (paperON == true && hasClicked == false)
        {
            StartCoroutine(ButtonReset());
            paperON = false;
            animator.SetBool("IsOpen", false);
            SFXAudioSource.GetComponent<SFXmanager>().PlaySoundEffect("cancel");
        }
        
    }
    public void SaveText()
    {
        NotebookText = InputField.text.ToString();
    }

    IEnumerator ButtonReset()
    {
        hasClicked = true;
        yield return new WaitForSeconds(0.5f);
        hasClicked = false;
    }

    private void Start()
    {
        paperON = false;
    }
    public void LoadText()
    {
        InputField.text = NotebookText;
    }
}
