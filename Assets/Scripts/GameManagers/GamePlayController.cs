using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace GameManagers
{
    public class GamePlayController : MonoBehaviour
    {

        public static GamePlayController instance;

        [SerializeField] private GameObject[] heroes;
        [SerializeField] private GameObject playerSpawnFX;
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private GameObject userInterface;
        private EnemySpawner enemySpawner;
        private PotionSpawner potionSpawner;
        [HideInInspector] public int enemy_Count;
        private bool secondWave, thirdWave;

        [SerializeField] private BossSpawnController bossSpawnControl;
        
        public delegate void SetCameraOnHealthBar();

        public static event SetCameraOnHealthBar cameraOn;

        private void Awake()
        {
            if (instance == null)
                instance = this;

            enemySpawner = GetComponent<EnemySpawner>();
            potionSpawner = GetComponent<PotionSpawner>();
        }
        
        public void SpawnPlayer()
        {
            StartCoroutine(SpawnPlayerAfterDelay());
        }

        IEnumerator SpawnPlayerAfterDelay()
        {
            playerSpawnFX.SetActive(true);

            yield return new WaitForSeconds(0.2f);

            Instantiate(heroes[GameManager.instance.selectedHeroIndex], playerSpawnPoint.position,Quaternion.Euler(0f,180f,0f));
        }

        public void SpawnEnemy(int enemyCount)
        {
            if (enemyCount == 1)
                userInterface.SetActive(true);
            
            enemy_Count = enemyCount;
            enemySpawner.SpawnEnemy(enemyCount);
            if (cameraOn != null)
                cameraOn();
        }

        public void EnemyDied()
        {
            enemy_Count--;
         
            if (enemy_Count == 0)
            {
                if (!secondWave)
                {
                    secondWave = true;
                    StartCoroutine(SpawnWave());
                } else if (!thirdWave)
                {
                    thirdWave = true;
                    StartCoroutine(SpawnWave());
                }
                else
                { 
                   potionSpawner.SpawnPotion();
                   bossSpawnControl.StarBossSpawn();
                }
            }
        }

        IEnumerator SpawnWave()
        {
            yield return new WaitForSeconds(3f);
            if (secondWave && !thirdWave)
            {
                potionSpawner.SpawnPotion();
                SpawnEnemy(2);
                if (cameraOn != null)
                    cameraOn();
            }
            else if (thirdWave)
            {
                potionSpawner.SpawnPotion();
                SpawnEnemy(3);
            }
        }

       
    }
}
