using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MovementSystem
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] public PlayerMovement playerMovement;

        [Header("Input")]
        [SerializeField] public PlayerInput playerInput;

        [Header("Camera Settings")]
        [SerializeField] public Transform cameraTransform;
        [SerializeField] public float lookSensitivity;

        private InputAction moveInputAction;
        //private InputAction jumpInputAction;
        private InputAction lookInputAction;

        //private float cameraRotationY;

        private void Awake()
        {
            cameraTransform = Camera.main.transform;

            MapInputActions();
        }

        private void Update()
        {
            //Movement
            var moveDirection = GetMoveDirection();
            playerMovement.Movement(moveDirection);

            //Camera
            var rotation = GetRotation();
            playerMovement.RotationHorinzontal(rotation.x * lookSensitivity);
        }

        private void LateUpdate()
        {
            //UpdateCamera();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void MapInputActions()
        {
            //Movement
            moveInputAction = playerInput.actions["Move"];

            //Jump
            //jumpInputAction = playerInput.actions["Jump"];
            //jumpInputAction.started += OnJumpInput;

            //Camera
            lookInputAction = playerInput.actions["Look"];
        }

        //private void OnJumpInput(InputAction.CallbackContext context)
        //{

        //}


        public Vector3 GetMoveDirection()
        {
            var moveInput = moveInputAction.ReadValue<Vector2>();
            return new Vector3(moveInput.x, 0f, moveInput.y);
        }
        private Vector2 GetRotation()
        {
            return lookInputAction.ReadValue<Vector2>();
        }

        //private void UpdateCamera()
        //{
        //    var rotation = GetRotation();

        //    cameraRotationY += -rotation.y * lookSensitivity;
        //    cameraRotationY = Math.Clamp(cameraRotationY, -90f, 90f);

        //    cameraTransform.eulerAngles = new Vector3(cameraRotationY, cameraTransform.eulerAngles.y, cameraTransform.eulerAngles.z);
        //}
    }
}

