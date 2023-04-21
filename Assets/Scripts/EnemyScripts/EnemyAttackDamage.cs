using HeroScripts;
using UnityEngine;

namespace EnemyScripts
{
    public class EnemyAttackDamage : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float radius = 1f;
        [SerializeField] private int damage = 1;
        
        // Update is called once per frame
        void Update()
        {
            Collider[] hit = Physics.OverlapSphere(transform.position, radius, layerMask);
            if (hit.Length > 0)
            {
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage);
                gameObject.SetActive(false);
            }
        }
    }
}
