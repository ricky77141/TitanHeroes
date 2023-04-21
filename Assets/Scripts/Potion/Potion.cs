using System;
using HeroScripts;
using UnityEngine;

namespace Potion
{
    public class Potion : MonoBehaviour
    {
        [SerializeField] private int health = 10;

        private void OnTriggerEnter(Collider other)
        {
            PotionSound.instance.PlayPotionSound();
            if (other.CompareTag(TagManager.PLAYER_TAG))
            {
                other.GetComponent<HealthScript>().HealthPlayer(health);
                this.gameObject.SetActive(false);
            }
        }
    }
}
