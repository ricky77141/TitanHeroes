using UnityEngine;
using Random = UnityEngine.Random;

namespace GameManagers
{
    public class PotionSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject potion;
        [SerializeField] private GameObject[] potionSpawnPoint;
        
        public void SpawnPotion()
        {
            Instantiate(potion, potionSpawnPoint[Random.Range(0,potionSpawnPoint.Length)].transform.position, Quaternion.identity);
        }
    }
}
