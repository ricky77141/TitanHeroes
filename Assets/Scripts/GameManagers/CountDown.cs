using System;
using UnityEngine;

namespace GameManagers
{
    public class CountDown : MonoBehaviour
    {
        private AudioSource audioSource;
        private Animator anim;
        [SerializeField] private GameObject count3, count2, count1;
        [SerializeField] private CameraAnimationsController cameraAnimationsController;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            anim = GetComponent<Animator>();
        }

        public void StartCountDown()
        {
            anim.enabled = true;
            CountDown3();
        }

        void CountDown3()
        {
            count3.SetActive(true);
        }

        void CountDown2()
        {
            count3.SetActive(false);
            count2.SetActive(true);
            anim.Play(AnimationTags.COUNT_2_ANIM);
        }

        void CountDown1()
        {
            count2.SetActive(false);
            count1.SetActive(true);
            anim.Play(AnimationTags.COUNT_1_ANIM);
        }

        void ActivateMainCamera()
        {
            count1.SetActive(false);
            cameraAnimationsController.TurnOnMainCamera();
        }

        void PlayCountDownSound()
        {
            audioSource.Play();
        }
        
    }
}
