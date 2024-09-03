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
    private Queue<string> names;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string> ();
        names = new Queue<string>();
        ContinueIcon.SetActive (false);
    }
    
    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue (sentence);
        }
        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
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
        string name = names.Dequeue();
        StopAllCoroutines();
        NameBox.text = name;
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
