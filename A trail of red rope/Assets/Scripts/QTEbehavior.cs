using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class QTEbehavior : MonoBehaviour
{
    public GameObject QTE;
    private bool qteON;
    private float TimerAmount = 1f;
    private float CurrentTimer;
    public int PassQTE;
    public event EventHandler OnQTEwin;


    // Start is called before the first frame update
    void Start()
    {
        QTE.SetActive(false);
        PassQTE = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (qteON == true)
        {
            //press Q here to complete QTE (Bool?) 
            if (Input.GetKeyDown(KeyCode.Space) && CurrentTimer > 0)
            {
                //if the button is pressed within the time frame this function will send out the QTEwin event 
                PassQTE = 1;
                OnQTEwin?.Invoke(this, EventArgs.Empty);
                QTE.SetActive(false);
                Debug.Log("QTE WIN");
                qteON = false;
                gameObject.GetComponent<GameManager>().UpdateGameState();
            }


            CurrentTimer -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && CurrentTimer < 0)
            {
                PassQTE = 2;
                QTE.SetActive(false);
                Debug.Log("QTE LOSE");
                qteON = false;
                gameObject.GetComponent<GameManager>().UpdateGameState();
            }
        }
    }

    public void QuickTimeEvent()
    {
        QTE.SetActive(true);
        CurrentTimer = TimerAmount;
        qteON = true;
    }
}
