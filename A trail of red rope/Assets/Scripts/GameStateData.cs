using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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
}
