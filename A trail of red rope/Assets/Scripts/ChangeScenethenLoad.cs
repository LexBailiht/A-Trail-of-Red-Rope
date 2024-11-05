using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenethenLoad : MonoBehaviour
{
    public GameObject GameManager;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void Load()
    {
        SceneManager.LoadScene("Lex - test");
        GameManager = GameObject.Find("GameManager");
        GameManager.GetComponent<Save>().RetrieveGameStateData();
    }
}
