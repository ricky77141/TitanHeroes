using UnityEngine;

namespace HeroScripts
{
    public class PlayerAttackDamageTrigger : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private bool isPlayer;

        private void OnTriggerEnter(Collider target)
        {
            if (isPlayer)
            {
                if (target.CompareTag(TagManager.ENEMY_TAG) || target.CompareTag(TagManager.BOSS_TAG))
                {
                    target.GetComponent<HealthScript>().ApplyDamage(damage);
                }
            }
            else
            {
                if (target.CompareTag(TagManager.PLAYER_TAG))
                {
                    target.GetComponent<HealthScript>().ApplyDamage(damage);
                }
            }
        }
    
    }
}
