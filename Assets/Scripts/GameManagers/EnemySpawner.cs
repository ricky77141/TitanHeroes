using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] bossEnemies;
    [SerializeField] private Transform[] enemySpawnPoint;
    [SerializeField] private GameObject bossSpawnFX;

    public void SpawnEnemy(int enemyCount)
    {
        for (int i=0; i < enemyCount; i++)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], enemySpawnPoint[i].position, Quaternion.identity);
        }
    }

    public void SpawnBoss(int bossIndex)
    {
        bossIndex = Random.Range(0, bossEnemies.Length);
        bossSpawnFX.SetActive(true);
        Instantiate(bossEnemies[bossIndex], enemySpawnPoint[1].position, Quaternion.identity);
    }
    
}
