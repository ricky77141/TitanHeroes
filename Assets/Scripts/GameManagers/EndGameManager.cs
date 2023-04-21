using System;
using System.Collections;
using HeroScripts;
using MainMenuScripts;
using UnityEngine;
using UnityEngine.UI;

namespace GameManagers
{
    public class EndGameManager : MonoBehaviour
    {
        public static EndGameManager instance;

        [SerializeField] private Image endGame;
        [SerializeField] private Sprite loseSprite, winSprite;
        [SerializeField] private AudioClip loseAudio, winAudio;
        private AudioSource myAudio;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            myAudio = GetComponent<AudioSource>();
        }

        public void GameOver(bool win)
        {
            StartCoroutine(RestartGame());
            
            endGame.gameObject.SetActive(true);

            if (win)
            {
                endGame.sprite = winSprite;
                myAudio.clip = winAudio;
                DeactivatePlayer();
            }
            else
            {
                endGame.sprite = loseSprite;
                myAudio.clip = loseAudio;
                DeactivateAllEnemyScripts();
            }
            myAudio.Play();
        }

        IEnumerator RestartGame()
        {
            Time.timeScale = 0f;

            yield return new WaitForSecondsRealtime(6f);

            Time.timeScale = 1f;
            LoadingScreen.instance.LoadLevel(SceneNames.MAIN_MENU);
        }

        void DeactivateAllEnemyScripts()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(TagManager.ENEMY_TAG);

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
                enemies[i].GetComponent<CharacterAnimation>().Walk(false);
            }

            GameObject boss = GameObject.FindGameObjectWithTag(TagManager.BOSS_TAG);

            if (boss != null)
            {
                boss.GetComponent<BossController>().enabled = false;
                boss.GetComponent<CharacterAnimation>().Walk(false);
            }
        }

        public void DeactivatePlayer()
        {
            GameObject player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);
            player.GetComponent<PlayerMoveKeyboard>().enabled = false;
            player.GetComponent<PlayerAttackInput>().enabled = false;
        }
    }
}
