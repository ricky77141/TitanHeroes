using System.Collections;
using SnazzlebotTools.ENPCHealthBars;
using UnityEngine;

namespace GameManagers
{
    public class BossSpawnController : MonoBehaviour
    {
        private Animator anim;

        [SerializeField] private GameObject bossSpawnCamera;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private float delayBeforeSpawnBoss = 2f;
        [SerializeField] private float delayBeforeBossFight = 4f;
        private ShakeCamera shakeCamera;
        private Camera faceCamera;
        private ENPCHealthBar healthBar;
        [SerializeField] private float shakeTime = 0.1f;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            shakeCamera = GetComponent<ShakeCamera>();
        }

        public void StarBossSpawn()
        {
            StartCoroutine(BossSpawnWithDelay());
        }

        IEnumerator BossSpawnWithDelay()
        {
            yield return new WaitForSecondsRealtime(delayBeforeSpawnBoss);
        
            Time.timeScale = 0f;
        
            bossSpawnCamera.SetActive(true);
            anim.Play(AnimationTags.SLIDE_IN_ANIM);
        }

        void ShakeAndSpawn()
        {
            StartCoroutine(ShakeCamAndSpawnBoss());
        }

        IEnumerator ShakeCamAndSpawnBoss()
        {
            shakeCamera.InitializeValues(shakeTime);
            enemySpawner.SpawnBoss(0);

            yield return new WaitForSecondsRealtime(shakeTime + delayBeforeBossFight);

            Time.timeScale = 1f;
            bossSpawnCamera.SetActive(false);
            faceCamera = GameObject.FindGameObjectWithTag(TagManager.MAIN_CAMERA).GetComponent<Camera>();
            healthBar = GameObject.FindGameObjectWithTag(TagManager.BOSS_TAG).GetComponent<ENPCHealthBar>();
            healthBar.FaceCamera = faceCamera;
        }
    }
}
