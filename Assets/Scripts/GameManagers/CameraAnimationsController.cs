using System;
using UnityEngine;

namespace GameManagers
{
    public class CameraAnimationsController : MonoBehaviour
    {
        private Animator anim;
        [SerializeField] private GameObject mainCamera, camera1, camera2;

        public delegate void ScreenMovement();

        public static event ScreenMovement screenMovement;

        [SerializeField] private CountDown countDown;
        [SerializeField] private Camera UICamera;
        [SerializeField] private GameObject fightFX;

       

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        void TurnOnCamera2()
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            anim.Play(AnimationTags.CAMERA_2_ANIM);
            GamePlayController.instance.SpawnPlayer();
        }

        public void TurnOnMainCamera()
        {
            camera2.SetActive(false);
            mainCamera.SetActive(true);

            if (screenMovement != null)
                screenMovement();

            Instantiate(fightFX,
                UICamera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f,
                    UICamera.nearClipPlane * 4)), Quaternion.identity);

            GamePlayController.instance.SpawnEnemy(1);

        }

        void StartCountDownAnim()
        {
            countDown.StartCountDown();
        }
    }
}
