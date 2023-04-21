using System;
using GameManagers;
using SnazzlebotTools.ENPCHealthBars;
using UnityEngine;

namespace HeroScripts
{
    public class HealthScript : MonoBehaviour
    {
        //[SerializeField] private float healthValue = 100f;
        [SerializeField] private bool isNormalEnemy;

        private Camera faceCamera;
        private ENPCHealthBar healthBar;
        private GameObject player;
    
        private CharacterAnimation characterAnim;

        //[SerializeField] private UIHealth displayHealth; 

        void Awake()
        {
            characterAnim = GetComponent<CharacterAnimation>();
            healthBar = GetComponent<ENPCHealthBar>();
        }
        
        private void OnEnable()
        {
            GamePlayController.cameraOn += AssignCamera;
        }

        private void OnDisable()
        {
            GamePlayController.cameraOn -= AssignCamera;
        }

        public void ApplyDamage(int damage)
        {
            healthBar.Value -= damage;

            if (healthBar.Value <= 0)
            {
                characterAnim.Dead();
            }
            else
            {
                if (isNormalEnemy)
                {
                    characterAnim.Hit();
                }
            }
        }

        public void HealthPlayer(int health)
        {
            if (healthBar.Value >= 100)
                return;

            healthBar.Value += health;
            
        }

        private void AssignCamera()
        {
            faceCamera = GameObject.FindGameObjectWithTag(TagManager.MAIN_CAMERA).GetComponent<Camera>();
            healthBar.FaceCamera = faceCamera;
        }
    }
}
