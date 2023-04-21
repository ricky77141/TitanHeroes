using System.Collections;
using UnityEngine;

namespace HeroScripts
{
    public class PlayerAttackDamage : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float radius = 1f;
        [SerializeField] private int damage = 1;
        [SerializeField] private bool dealMultipleDamage;
        [SerializeField] private bool disableScript;
        [SerializeField] private bool detectColAfterDelay;
        [SerializeField] private float delayTime = 1f;
        private bool canDetectCol = true;

        private void Awake()
        {
            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            if (detectColAfterDelay)
            {
                canDetectCol=false;
                StartCoroutine(CollisionAfterDelay());
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (canDetectCol)
            {
                DetectCollision();
            }
        }

        void DetectCollision()
        {

            int maxColliders = 4;
            
            //Collider[] hit = Physics.OverlapSphere(transform.position, radius, layerMask);
            Collider[] hit = new Collider[maxColliders];
            int numColliders = Physics.OverlapSphereNonAlloc(transform.position, radius, hit,layerMask);
            if (numColliders > 0)
            {
                if (dealMultipleDamage)
                {
                    for (int i = 0; i < numColliders; i++)
                    {
                       hit[i].GetComponent<HealthScript>().ApplyDamage(damage);
                    }
                }
                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage);
                }

                if (disableScript)
                {
                    enabled = false;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
        
        IEnumerator CollisionAfterDelay()
        {
            yield return new WaitForSeconds(delayTime);
            canDetectCol = true;
        }
    }
}
