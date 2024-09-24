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
    private Queue<string> sfxs;
    private Queue<string> musics;
    private Queue<string> backgrounds;
    private Queue<string> animations;
    public Animator animator;
    public GameObject ButtonPanel;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string> ();
        names = new Queue<string>();
        sfxs = new Queue<string>();
        musics = new Queue<string>();
        backgrounds = new Queue<string>();
        animations = new Queue<string>();
        ContinueIcon.SetActive (false);
    }
    
    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        ButtonPanel.SetActive (false);
        sentences.Clear();
        names.Clear();
        sfxs.Clear();
        musics.Clear();
        backgrounds.Clear();
        animations.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue (sentence);
        }
        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }
        foreach (string sfx in dialogue.sfxs)
        {
            sfxs.Enqueue(sfx);
        }
        foreach (string music in dialogue.musics)
        {
            musics.Enqueue(music);
        }
        foreach (string background in dialogue.backgrounds)
        {
            backgrounds.Enqueue(background);
        }
        foreach (string animation in dialogue.animations)
        {
            animations.Enqueue(animation);
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
        string sfx = sfxs.Dequeue();
        string music = musics.Dequeue();
        string background = backgrounds.Dequeue();
        string animation = animations.Dequeue();
        StopAllCoroutines();
        NameBox.text = name;
        if (sfx != string.Empty)
        {
            BroadcastMessage("PlaySoundEffect", sfx);
        }
        if (music != string.Empty)
        {
            BroadcastMessage("PlayMusic", music);
        }
        if (background != string.Empty)
        {
            BroadcastMessage("SetBackground", background);
        }
        if (animation != string.Empty)
        {
            BroadcastMessage("SetAnimation", animation);
        }
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
        ButtonPanel.SetActive(true);
    }
}
