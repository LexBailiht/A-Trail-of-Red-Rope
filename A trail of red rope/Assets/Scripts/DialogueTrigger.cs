using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;
    public int dialoguenumber;
    public GameObject GameManager;
    public void TriggerDialogue()
    {
        dialoguenumber = GameManager.GetComponent<GameManager>().DialogueNumber;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[dialoguenumber]);
        gameObject.SetActive(false);
    }
}
