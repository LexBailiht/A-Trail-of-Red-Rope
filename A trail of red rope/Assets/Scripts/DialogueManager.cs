using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI DialogueBox;
    public GameObject NameBoxBox;
    public TextMeshProUGUI NameBox;
    public float delay = 0.0175f;
    public Slider DelaySlider;
    public bool SpedUp = false;
    public bool AutoContinue = false;
    public Toggle AutoContinueToggle;
    public bool DefaultAutoContinue = false;
    public bool SkipCurrentSentence = false;
    public GameObject ContinueIcon;
    public GameObject GameManager;
    public AudioSource SFXAudioSource;
    public Queue<string> sentences;
    public Queue<string> names;
    public Queue<string> sfxs;
    public Queue<string> musics;
    public Queue<string> backgrounds;
    public Queue<string> animations;
    public Animator animator;
    public GameObject ButtonPanel;
    public int CurrentDialogue;
    public Dialogue Dialogue;
    private int LengthOfQueue;
    public GameObject PlayButton;
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
        PlayButton.SetActive (false);  
        Dialogue = dialogue;
        GameManager.GetComponent<GameManager>().LastDialogueNumber = dialogue.dialogueidentifier;
        if (dialogue.button == "talk")
        {
            GameManager.GetComponent<GameManager>().TalkLastDialogueNumber = dialogue.dialogueidentifier;
        }
        if (dialogue.button == "scrutinize")
        {
            GameManager.GetComponent<GameManager>().ScrutinizeLastDialogueNumber = dialogue.dialogueidentifier;
        }
        if (dialogue.button == "investigate")
        {
            GameManager.GetComponent<GameManager>().InvestigateLastDialogueNumber = dialogue.dialogueidentifier;
        }
        if (dialogue.button == "move")
        {
            GameManager.GetComponent<GameManager>().MoveLastDialogueNumber = dialogue.dialogueidentifier;
        }
        GameManager.GetComponent<GameManager>().UpdateGameState();
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
        if (CurrentDialogue > 0)
        {
            GoToLastDialogueState();
        }
        DisplayNextSentence();
    }
    public void GoToLastDialogueState()
    {
        LengthOfQueue = sentences.Count;
        for (int i = 0; i < (CurrentDialogue-1); i++)
        {
            sentences.Dequeue();
            names.Dequeue();
            sfxs.Dequeue();
            musics.Dequeue();
            backgrounds.Dequeue();
            animations.Dequeue();
        }

    }
    public void DisplayNextSentence()
    {

            CurrentDialogue += 1;
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
            if (name.Length == 0)
            { 
                NameBoxBox.SetActive(false);
            }
            else
            {
                NameBoxBox.SetActive(true);
            }
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
            if (letter == ' ' && SFXAudioSource.GetComponent<AudioSource>().isPlaying != true)
            {
                SFXAudioSource.GetComponent<SFXmanager>().PlaySoundEffect("blipmale");
            }

            if (SkipCurrentSentence == true)
            {
                yield return new WaitForSeconds(delay/8);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
            }
            if (AutoContinue == true)
            {
                yield return new WaitForSeconds(delay * 30);
            }
            ContinueIcon.SetActive(true);
            SkipCurrentSentence = false;
            if (AutoContinue == true && GameManager.GetComponent<GameManager>().SettingsState != true)
            {
                DisplayNextSentence();
            }
    }

    public void ToggleAutoContinue()
    {
        if (AutoContinueToggle.isOn == true)
        {
            DefaultAutoContinue = true;
        } else
        {
            DefaultAutoContinue = false;
        }
        AutoContinue = DefaultAutoContinue;
    }
    public void OnDelayChanged()
    {
        delay = DelaySlider.value; 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnClick();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            OnRelease();
        }
    }
    public void OnClick()
    {
        if (ContinueIcon.activeInHierarchy == true && GameManager.GetComponent<GameManager>().SettingsState != true)
        {
            DisplayNextSentence();
        } else
        {
            SkipCurrentSentence = true;
        }
        Invoke("SpeedUp", 0.25f);  
    }
    public void OnRelease()
    {
        CancelInvoke("SpeedUp");
        delay = DelaySlider.value;
        AutoContinue = DefaultAutoContinue;
        SpedUp = false;
    }
    void SpeedUp()
    {
        AutoContinue = true;
        if (ContinueIcon.activeInHierarchy == true && GameManager.GetComponent<GameManager>().SettingsState != true)
        {
            DisplayNextSentence();
        }
        delay = DelaySlider.value / 2;
        SpedUp = true;
    }
    public void EndDialogue()
    {
        PlayButton.gameObject.SetActive(false);
        CurrentDialogue = 0;
        ContinueIcon.SetActive(false);
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation.");
        if (GameManager.GetComponent<GameManager>().TalkLastDialogueNumber == 2)
        {
            GameManager.GetComponent<QTEbehavior>().QuickTimeEvent();
        }
        else if (GameManager.GetComponent<GameManager>().TalkLastDialogueNumber == 3 || GameManager.GetComponent<GameManager>().TalkLastDialogueNumber == 4)
        {
            GameManager.GetComponent<GameManager>().EndDemo();
        }
        else
        {
            ButtonPanel.SetActive(true);
        }
    }
}
