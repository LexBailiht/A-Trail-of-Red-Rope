using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotepadTrigger : MonoBehaviour
{
    public GameObject Paper;
    private bool paperON;
    //public Button button;
    public bool hasClicked = false;

   public void Onclick()
    {
        if (paperON == false && hasClicked == false) 
        {
           StartCoroutine(ButtonReset());
            Paper.SetActive(true);
            paperON = true;
        }
    }

    public void CloseNotebook()
    {
        if (paperON == true && hasClicked == false)
        {
            StartCoroutine(ButtonReset());
            Paper.SetActive(false);
            paperON = false;
        }
        
    }

    IEnumerator ButtonReset()
    {
        hasClicked = true;
        yield return new WaitForSeconds(1);
        hasClicked = false;
    }

    private void Start()
    {
        Paper.SetActive(false);
        paperON = false;
    }
}
