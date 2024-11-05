using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameStateData
{
    public AudioClip selectedSFX;
    public AudioClip selectedOST;

    public int DialogueNumber;
    public int LastDialogueNumber;
    public int TalkDialogueNumber;
    public int TalkLastDialogueNumber;
    public int ScrutinizeDialogueNumber;
    public int ScrutinizeLastDialogueNumber;
    public int InvestigateDialogueNumber;
    public int InvestigateLastDialogueNumber;
    public int MoveDialogueNumber;
    public int MoveLastDialogueNumber;

    public GameObject SelectedAnimation;
    public GameObject SelectedBackground;

    public int CurrentDialogue;
    public Dialogue Dialogue;

    public bool qteON;
    public int PassQTE;

    public string NotebookText;

    public GameStateData(GameManager gameManager, GameObject OSTManager, GameObject SFXManager, GameObject BackgroundManager, GameObject AnimationManager, GameObject DialogueManager, GameObject QTEbehavior, GameObject NotepadTrigger)
    {
        DialogueNumber = gameManager.DialogueNumber;
        LastDialogueNumber = gameManager.LastDialogueNumber;
        TalkDialogueNumber = gameManager.TalkDialogueNumber;
        TalkLastDialogueNumber = gameManager.TalkLastDialogueNumber;
        ScrutinizeDialogueNumber = gameManager.ScrutinizeLastDialogueNumber;
        ScrutinizeLastDialogueNumber= gameManager.ScrutinizeLastDialogueNumber;
        InvestigateDialogueNumber = gameManager.InvestigateDialogueNumber;
        InvestigateLastDialogueNumber = gameManager.InvestigateLastDialogueNumber; ;
        MoveDialogueNumber = gameManager.MoveDialogueNumber;
        MoveLastDialogueNumber = gameManager.MoveLastDialogueNumber;

        selectedOST = OSTManager.GetComponent<OSTchanger>().selectedOST;
        selectedSFX = SFXManager.GetComponent<SFXmanager>().selectedSFX;

        SelectedBackground = BackgroundManager.GetComponent<BackgroundManager>().SelectedBackground;
        SelectedAnimation = AnimationManager.GetComponent<AnimationManager>().SelectedAnimation;

        CurrentDialogue = DialogueManager.GetComponent<DialogueManager>().CurrentDialogue;
        Dialogue = DialogueManager.GetComponent<DialogueManager>().Dialogue;

        qteON = QTEbehavior.GetComponent<QTEbehavior>().qteON;
        PassQTE = QTEbehavior.GetComponent<QTEbehavior>().PassQTE;

        NotebookText = NotepadTrigger.GetComponent<NotepadTrigger>().NotebookText;
    }

}
