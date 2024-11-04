using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.Arm;

public class Save : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject OSTManager;
    public GameObject SFXManager;
    public GameObject BackgroundManager;
    public GameObject AnimationManager;
    public GameObject DialogueManager;
    public GameObject QTEbehavior;
    public string path;
    public GameStateData loadedGameStateData;
    public void SaveGame()
    {
        loadedGameStateData = new GameStateData(gameManager, OSTManager, SFXManager, BackgroundManager, AnimationManager, DialogueManager, QTEbehavior);
        string json = JsonUtility.ToJson(loadedGameStateData);

        path = Application.persistentDataPath  + "/GameStateData.json";
        File.WriteAllText(path, json);


    }
    private void Start()
    {
        path = Application.persistentDataPath + "/GameStateData.json";
    }
    public void RetrieveGameStateData()
    {
        if (File.Exists(path))
        {
            string loaddata = File.ReadAllText(path);
            loadedGameStateData = JsonUtility.FromJson<GameStateData>(loaddata);

            LoadGame(gameManager, OSTManager, SFXManager, BackgroundManager, AnimationManager, DialogueManager, QTEbehavior);
        }
        else
        {
            Debug.Log("There is no save files to load!");
        }

    }
    public void LoadGame(GameManager gameManager, GameObject OSTManager, GameObject SFXManager, GameObject BackgroundManager, GameObject AnimationManager, GameObject DialogueManager, GameObject QTEbehavior)
    {
        //SceneManager.LoadScene("Lex - test");
        gameManager.DialogueNumber = loadedGameStateData.DialogueNumber;
        gameManager.LastDialogueNumber = loadedGameStateData.LastDialogueNumber;
        gameManager.TalkDialogueNumber = loadedGameStateData.TalkDialogueNumber;
        gameManager.TalkLastDialogueNumber = loadedGameStateData.TalkLastDialogueNumber;
        gameManager.ScrutinizeLastDialogueNumber = loadedGameStateData.ScrutinizeDialogueNumber;
        gameManager.ScrutinizeLastDialogueNumber = loadedGameStateData.ScrutinizeLastDialogueNumber;
        gameManager.InvestigateDialogueNumber = loadedGameStateData.InvestigateDialogueNumber;
        gameManager.InvestigateLastDialogueNumber = loadedGameStateData.InvestigateLastDialogueNumber; ;
        gameManager.MoveDialogueNumber = loadedGameStateData.MoveDialogueNumber;
        gameManager.MoveLastDialogueNumber = loadedGameStateData.MoveLastDialogueNumber;

        OSTManager.GetComponent<OSTchanger>().selectedOST = loadedGameStateData.selectedOST;
        SFXManager.GetComponent<SFXmanager>().selectedSFX = loadedGameStateData.selectedSFX;

        BackgroundManager.GetComponent<BackgroundManager>().SelectedBackground = loadedGameStateData.SelectedBackground;
        BackgroundManager.GetComponent<BackgroundManager>().LoadBackground();
        AnimationManager.GetComponent<AnimationManager>().ClearAnimation();
        AnimationManager.GetComponent<AnimationManager>().SelectedAnimation = loadedGameStateData.SelectedAnimation;
        AnimationManager.GetComponent<AnimationManager>().LoadAnimation();

        DialogueManager.GetComponent<DialogueManager>().CurrentDialogue = loadedGameStateData.CurrentDialogue;
        if (loadedGameStateData.CurrentDialogue != 0)
        {
            DialogueManager.GetComponent<DialogueManager>().StartDialogue(loadedGameStateData.Dialogue);
        } else
        {
            DialogueManager.GetComponent<DialogueManager>().EndDialogue();
        }
        OSTManager.GetComponent<OSTchanger>().LoadMusic();

        QTEbehavior.GetComponent<QTEbehavior>().qteON = loadedGameStateData.qteON;
        QTEbehavior.GetComponent<QTEbehavior>().PassQTE = loadedGameStateData.PassQTE;
    }
}
