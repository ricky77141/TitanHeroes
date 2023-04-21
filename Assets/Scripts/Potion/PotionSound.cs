using UnityEngine;

namespace Potion
{
    public class PotionSound : MonoBehaviour
    {
        public static PotionSound instance;
        
        [SerializeField] private AudioSource potionSound;
        [SerializeField] private AudioClip myClip;

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        public void PlayPotionSound()
        {
            potionSound.clip = myClip;
            potionSound.Play();
        }
    }
}
