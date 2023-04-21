using UnityEngine;

namespace EnemyScripts
{
    public class BossSpecialAttack : MonoBehaviour
    {
        [SerializeField] private GameObject specialAttackPref;
        [SerializeField] private Transform specialAttackPoint;
        [SerializeField] private bool isCerberus;

        void SpawnSpecialAttack()
        {
            if (isCerberus)
                Instantiate(specialAttackPref, specialAttackPoint.position, transform.rotation);
            else
                Instantiate(specialAttackPref, specialAttackPoint.position, Quaternion.identity);
            
        }
    }
}
