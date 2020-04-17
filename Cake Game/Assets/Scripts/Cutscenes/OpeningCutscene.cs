using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpeningCutscene : MonoBehaviour
{

    public PlayableDirector director;
    public Animator playerAnimator;
    public RuntimeAnimatorController playerAnimation;
    public bool fix = false;


    /* void OnEnable()
     {
         playerAnimation = playerAnimator.runtimeAnimatorController;
         playerAnimator.runtimeAnimatorController = null;
     }*/

    void Start()
    {
        director.Play();
    }


    void Update()
    {
        if (director.state != PlayState.Playing && !fix)
        {
            Debug.Log("Stopped Playing");
            PlayerPrefs.SetInt("Opening", 1);
            PlayerPrefs.SetInt("Day", 1);
        }

    }

}
