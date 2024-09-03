using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEtest : MonoBehaviour
{
    public Button QTE_test;
    public event EventHandler OnQTEtest;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    void OnPLayerCLick()
    {
        OnQTEtest?.Invoke(this, EventArgs.Empty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
