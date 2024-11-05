using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject HarbourBackground;
    public GameObject OfficeBackground;
    public GameObject DefaultBackground;

    public GameObject SelectedBackground;
    // Start is called before the first frame update

    private void Start()
    {
        SelectedBackground= DefaultBackground;
    }
    public void SetBackground(string background)
    {
        SelectedBackground.SetActive(false);
        if (background == "harbour")
        {
            SelectedBackground = HarbourBackground;
        }
        if (background == "office")
        {
            SelectedBackground = OfficeBackground;
        }
        if (background == "default")
        {
            SelectedBackground = DefaultBackground;
        }

        SelectedBackground.SetActive(true);
    }
    public void LoadBackground()
    {
        SelectedBackground.SetActive(true);
    }
    public void ClearBackground()
    {
        SelectedBackground.SetActive(false);
    }
}
