using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject Miles;
    public GameObject Barry;
    public GameObject Giovanni;
    private GameObject SelectedAnimation;
    // Start is called before the first frame update
    void Start()
    {
        Miles.SetActive(false);
        Barry.SetActive(false);
        Giovanni.SetActive(false);
        SelectedAnimation = Miles;
    }

    public void SetAnimation(string animation)
    {
        SelectedAnimation.SetActive(false);
        if (animation == "miles")
        {
            SelectedAnimation = Miles;
        }
        if (animation == "barry")
        {
            SelectedAnimation = Barry;
        }
        if (animation == "giovanni")
        {
            SelectedAnimation = Giovanni;
        }

        SelectedAnimation.SetActive(true);
    }
}
