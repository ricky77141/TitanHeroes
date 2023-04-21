using System;
using System.Collections;
using System.Collections.Generic;
using HeroScripts.GameManagers;
using UnityEngine;

public class CharacterAnimationMainMenu : MonoBehaviour
{
    private Animator myAnim;
    [SerializeField] private GameObject mainPanel;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
    }

    void TurnOnRootMotion()
    {
        myAnim.applyRootMotion = true;
    }

    void AppearGround()
    {
        MainMenuAnimController.instance.FloorSlideIn();
    }

    void ThunderFX()
    {
        MainMenuAnimController.instance.ActivateThunderFX();
    }

    void HeroAppearSound()
    {
        MainMenuAnimController.instance.PlayHeroAppearSound();
    }
    
    void OpenMainCanvas()
    {
        mainPanel.SetActive(true);
    }
}
