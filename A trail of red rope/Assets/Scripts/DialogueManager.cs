using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI DialogueBox;
    public TextMeshProUGUI NameBox;
    public GameObject ContinueIcon;
    private Queue<string> sentences;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string> ();
        ContinueIcon.SetActive (false);
    }
    
    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        NameBox.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue (sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        ContinueIcon.SetActive(false);
        DialogueBox.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueBox.text += letter; 
            yield return new WaitForSeconds(0.025f);
        }
        ContinueIcon.SetActive(true);
    }

    void EndDialogue()
    {
        ContinueIcon.SetActive(false);
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation.");

    }
}
