using UnityEngine;

namespace HeroScripts
{
    public class CharacterSoundController : MonoBehaviour
    {

        [SerializeField] private AudioSource playerAttackSound;
        [SerializeField] private AudioSource playerAttackSound2;

        void PlayPlayerAttackSound()
        {
            playerAttackSound.Play();
        }
        
        void PlayPlayerAttackSound2()
        {
            playerAttackSound2.Play();
        }
    }
}
