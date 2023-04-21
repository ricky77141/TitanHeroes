using UnityEngine;

namespace EnemyScripts
{
    public class AttackDamageController : MonoBehaviour
    {
        [SerializeField] private GameObject attackPoint1;
        [SerializeField] private GameObject attackPoint2;
        private bool isActive;

        void TurnOnAttackPoint1()
        {
            attackPoint1.SetActive(true);
        }

        void TurnOffAttackPoint1()
        {
            if (attackPoint1.activeInHierarchy)
            {
                attackPoint1.SetActive(false);
            }
            
        }
    
        void TurnOnAttackPoint2()
        {
            attackPoint2.SetActive(true);
        }

        void TurnOffAttackPoint2()
        {
            if (attackPoint2.activeInHierarchy)
            {
                attackPoint2.SetActive(false);
            }
        }
    }
}
