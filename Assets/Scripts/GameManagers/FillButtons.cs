using System;
using HeroScripts;
using UnityEngine;
using UnityEngine.UI;

namespace GameManagers
{
    public class FillButtons : MonoBehaviour
    {

        [SerializeField] private Image[] fillButtons;
        [SerializeField] private float time1, time2, time3;
        private float time1BU, time2BU, time3BU;

        public delegate void ActivateButton(int whatBool);

        public static event ActivateButton finishUnfill;

        private void Awake()
        {
            time1BU = time1;
            time2BU = time2;
            time3BU = time3;
        }

        private void OnEnable()
        {
            PlayerAttackInput.clicked += RefillButtons;
        }

        private void OnDisable()
        {
            PlayerAttackInput.clicked -= RefillButtons;
        }

        private void Update()
        {
            UnfillButtons();
        }

        private void UnfillButtons()
        {
            /*if (fillButtons[0].fillAmount >= 1 || fillButtons[1].fillAmount >= 1 || fillButtons[2].fillAmount >= 1)
                return;*/
            
            if (time1 > 0)
            {
                time1 -= Time.unscaledDeltaTime;
                fillButtons[0].fillAmount = time1 * (1/time1BU);
            }
            else
            {
                if (finishUnfill != null)
                    finishUnfill(1);
            }

            if (time2 > 0)
            {
                time2 -= Time.unscaledDeltaTime;
                fillButtons[1].fillAmount = time2 * (1/time2BU);
            }else
            {
                if (finishUnfill != null)
                    finishUnfill(2);
            }
            
            if (time3 > 0)
            {
                time3 -= Time.unscaledDeltaTime;
                fillButtons[2].fillAmount = time3 * (1/time3BU);
            }else
            {
                if (finishUnfill != null)
                    finishUnfill(3);
            }
        }

        void RefillButtons(int theButton)
        {
            switch (theButton)
            {
                case 1:
                    fillButtons[0].fillAmount = 1f;
                    time1 = time1BU;
                    break;
                case 2:
                    fillButtons[1].fillAmount = 1f;
                    time2 = time2BU;
                    break;
                case 3:
                    fillButtons[2].fillAmount = 1f;
                    time3 = time3BU;
                    break;
            }
        }
    }
}
