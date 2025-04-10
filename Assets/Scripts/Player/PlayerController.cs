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

        [Header("Interaction")]
        [SerializeField] public ClosestTargetProvider interactableProvider;

        [Header("Input")]
        [SerializeField] public PlayerInput playerInput;

        [Header("Camera Settings")]
        [SerializeField] public Transform cameraTransform;
        [SerializeField] public float lookSensitivity;

        private InputAction moveInputAction;
        private InputAction lookInputAction;
        private InputAction interactInputAction;

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

            //Interaction
            
        }

        private void LateUpdate()
        {
          
        }

        private void MapInputActions()
        {
            //Movement on WSAD
            moveInputAction = playerInput.actions["Move"];


            //Camera on MOUSE
            lookInputAction = playerInput.actions["Look"];

            //Interaction on "E"
            interactInputAction = playerInput.actions["Interact"];
            interactInputAction.started += OnInteractionInput;
        }

        

        private void OnInteractionInput(InputAction.CallbackContext context)
        {
            var closestInteractable = interactableProvider.GetTarget<Interactable>();
            if (closestInteractable == false)
            {
                return;
            }
            closestInteractable.Interact();
        }

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

