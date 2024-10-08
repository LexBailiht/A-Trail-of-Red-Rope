using System.Collections;
using System.Collections.Generic;
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
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateGameState()
    {
        if (TalkLastDialogueNumber == 1)
        {
            TalkDialogueNumber = 1;
        }
    }
}
