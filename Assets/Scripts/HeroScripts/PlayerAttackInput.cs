using System;
using System.Collections;
using System.Net.Security;
using GameManagers;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;
using UnityEngine.UI;

namespace HeroScripts
{
    public class PlayerAttackInput : MonoBehaviour
    {

        private CharacterAnimation playerAnimation;

        private PlayerInputs playerInput;

        private bool canAttackAgainSP1;
        private bool canAttackAgainSP2;
        private bool canAttackAgainSP3;

        [SerializeField] bool isLianYou;
        
        public delegate void FillTheButtons(int buttonToActivate);

        public static event FillTheButtons clicked;
            
    
        // Start is called before the first frame update
        void Awake()
        {
            playerInput = new PlayerInputs();
            playerAnimation = GetComponent<CharacterAnimation>();
            playerInput.Attack.MainAttack.performed += MainAttack;
            playerInput.Attack.SpecialAttack1.performed += SPAttack1;
            playerInput.Attack.SpecialAttack2.performed += SPAttack2;
            playerInput.Attack.SpecialAttack3.performed += SPAttack3;
        }

        private void OnEnable()
        {
            FillButtons.finishUnfill += ActivateButtons;
            playerInput.Attack.Enable();
        }

        private void OnDisable()
        {
            FillButtons.finishUnfill -= ActivateButtons;
            playerInput.Attack.Disable();
        }
        
        void MainAttack(InputAction.CallbackContext ctx)
        {
            if (isLianYou)
            {
                if (Random.Range(0, 2) > 0)
                    playerAnimation.NormalAttack();
                else
                    playerAnimation.NormalAttack2();
            }
            else
            {
                playerAnimation.NormalAttack();
            }
        }

        void SPAttack1(InputAction.CallbackContext ctx1)
        {
            if (canAttackAgainSP1)
            {
                canAttackAgainSP1 = false;
                playerAnimation.SpecialAttack1();
                if (clicked != null)
                    clicked(1);
            }
        }
        
        void SPAttack2(InputAction.CallbackContext ctx2)
        {
            
            if (canAttackAgainSP2)
            {
                canAttackAgainSP2 = false;
                playerAnimation.SpecialAttack2();
                if (clicked != null)
                    clicked(2);

            }
        }

        void SPAttack3(InputAction.CallbackContext ctx3)
        {
            if (canAttackAgainSP3)
            {
                canAttackAgainSP3 = false;
                playerAnimation.SpecialAttack3();
                if (clicked != null)
                    clicked(3);
            }
        }
        

        void ActivateButtons(int theButton)
        {
            switch (theButton)
            {
                case 1:
                    canAttackAgainSP1 = true;
                    break;
                case 2:
                    canAttackAgainSP2 = true;
                    break;
                case 3:
                    canAttackAgainSP3 = true;
                    break;
            }
        }
    }
}
