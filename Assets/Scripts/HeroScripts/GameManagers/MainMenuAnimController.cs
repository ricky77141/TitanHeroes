using System;
using System.Collections;
using UnityEngine;
using Cinemachine;

namespace HeroScripts.GameManagers
{
    public class MainMenuAnimController : MonoBehaviour
    {
        public static MainMenuAnimController instance;

        private AudioSource heroesAppearSound;

        [SerializeField] private GameObject[] thunderFX;
        [SerializeField] private Animator[] heroAnim;
        [SerializeField] private Animator floorAnim;
        [SerializeField] private float appearHeroTime = 2f;
        [SerializeField] private float shakeTime = 0.1f;
        [SerializeField] private CinemachineVirtualCamera cinemaCam;
        private CinemachineBasicMultiChannelPerlin shakeFX;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            
            heroesAppearSound = GetComponent<AudioSource>();
        }
        
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(ActivateAnimations());

            shakeFX = cinemaCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        }

        public void FloorSlideIn()
        {
            floorAnim.Play(AnimationTags.SLIDE_IN_ANIM);
        }

        public void PlayHeroAppearSound()
        {
            heroesAppearSound.Play();
        }

        public void ActivateThunderFX()
        {
            //heroesAppearSound.Stop();
            for (int i = 0; i < thunderFX.Length; i++)
            {
                thunderFX[i].SetActive(true);
            }

            StartCoroutine(ShakeCamera());
        }

        IEnumerator ActivateAnimations()
        {
            yield return new WaitForSeconds(appearHeroTime);
            
            for (int i = 0; i < heroAnim.Length; i++)
            {
                heroAnim[i].Play(AnimationTags.SLIDE_IN_ANIM);
            }
        }

        IEnumerator ShakeCamera()
        {
            shakeFX.m_AmplitudeGain = 10;
            shakeFX.m_FrequencyGain = 3f;

            yield return new WaitForSeconds(shakeTime);
            
            shakeFX.m_AmplitudeGain = 0;
            shakeFX.m_FrequencyGain = 0f;
        }
    }
}
