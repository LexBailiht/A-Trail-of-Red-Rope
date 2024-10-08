using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public int dialogueidentifier;
    public string button;
    public string[] names;

    [TextArea(3, 10)]
    public string[] sentences;
    public string[] musics;
    public string[] sfxs;
    public string[] backgrounds;
    public string[] animations;
}
