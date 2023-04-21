using System;
using GameManagers;
using UnityEngine;

namespace HeroScripts
{
    public class PlayerMoveKeyboard : MonoBehaviour
    {
        private BaseMovement _baseMovement;
        private CharacterAnimation playerAnimation;

        private Quaternion screenMovementSpace;
        private Vector3 screenMovementForward;
        private Vector3 screenMovementRight;
        private PlayerInputs playerInput;
        private Vector2 moveInput;
    
        void Awake()
        {
            playerInput = new PlayerInputs();
            _baseMovement = GetComponent<BaseMovement>();
            _baseMovement.movementDirection = Vector3.zero;
            playerAnimation = GetComponent<CharacterAnimation>();
        }

        private void Start()
        {
            SetScreenMovement();
        }

        private void OnEnable()
        {
            CameraAnimationsController.screenMovement += SetScreenMovement;
            playerInput.PlayerMove.Enable();
        }

        private void OnDisable()
        {
            CameraAnimationsController.screenMovement -= SetScreenMovement;
            playerInput.PlayerMove.Disable();
        }

        // Update is called once per frame
        void Update()
        {
            MovementInput();
        }

        void MovementInput()
        {
            moveInput = playerInput.PlayerMove.Movement.ReadValue<Vector2>();
            //_baseMovement.movementDirection = Input.GetAxis(AxisManager.HORIZONTAL_AXIS) * screenMovementRight 
            //                                 + Input.GetAxis(AxisManager.VERTICAL_AXIS) * screenMovementForward;
            _baseMovement.movementDirection = moveInput.x * screenMovementRight 
                                             + moveInput.y * screenMovementForward;


             //Animation
            //if (Input.GetAxis(AxisManager.HORIZONTAL_AXIS) != 0 || Input.GetAxis(AxisManager.VERTICAL_AXIS) != 0)
            if (moveInput.x != 0 || moveInput.y != 0)
            {
                playerAnimation.Walk(true);
            }
            else
            {
                playerAnimation.Walk(false);
            }
        
            if (_baseMovement.movementDirection.sqrMagnitude > 1) 
                _baseMovement.movementDirection.Normalize();
        
        }

        void SetScreenMovement()
        {
            if (Camera.main is { }) screenMovementSpace = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
            screenMovementForward = screenMovementSpace * Vector3.forward;
            screenMovementRight = screenMovementSpace * Vector3.right;
        }

        void PlayerDied()
        {
            EndGameManager.instance.GameOver(false);
            GetComponent<PlayerAttackInput>().enabled = false;
            enabled = false;
        }
    
    
    }
}
