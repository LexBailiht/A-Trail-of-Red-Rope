using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;
    public int dialoguenumber;
    public int talkdialoguenumber;
    public int scrutinizedialoguenumber;
    public int investigatedialoguenumber;
    public int movedialoguenumber;
    public GameObject GameManager;
    public void TriggerDialogue()
    {
        dialoguenumber = GameManager.GetComponent<GameManager>().DialogueNumber;
        talkdialoguenumber = GameManager.GetComponent<GameManager>().TalkDialogueNumber;
        scrutinizedialoguenumber = GameManager.GetComponent<GameManager>().ScrutinizeDialogueNumber;
        investigatedialoguenumber = GameManager.GetComponent<GameManager>().InvestigateDialogueNumber;
        movedialoguenumber = GameManager.GetComponent<GameManager>().MoveDialogueNumber;
        if (gameObject.tag == "talk")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue[talkdialoguenumber]);
        }
        if (gameObject.tag == "scrutinize")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue[scrutinizedialoguenumber]);
        }
        if (gameObject.tag == "investigate")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue[investigatedialoguenumber]);
        }
        if (gameObject.tag == "move")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue[movedialoguenumber]);
        }
        if (gameObject.tag != "talk" && gameObject.tag != "scrutinize" && gameObject.tag != "investigate" && gameObject.tag != "move")
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[dialoguenumber]);
        if (gameObject.tag == "playbutton")
        {
            gameObject.SetActive(false);
        }
    }
}
