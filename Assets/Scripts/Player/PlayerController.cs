using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace MovementSystem
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] public PlayerMovement playerMovement;

        [Header("Interaction")]
        [SerializeField] public ClosestTargetProvider interactableProvider;
        [SerializeField] public Inventory inventory;

        [Header("Input")]
        [SerializeField] public PlayerInput playerInput;

        [Header("Camera Settings")]
        [SerializeField] public Transform cameraTransform;
        [SerializeField] public float lookSensitivity;

        private InputAction moveInputAction;
        private InputAction lookInputAction;
        private InputAction interactInputAction;
        private InputAction openInventoryAction;

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
            //var rotation = GetMoveDirection();    //try getting Rotation over WSAD
            playerMovement.RotationHorinzontal(rotation.x * lookSensitivity);
            //playerMovement.RotationHorinzontal(rotation.x);
        }

        private void MapInputActions()
        {
            //Movement on WSAD
            moveInputAction = playerInput.actions["Move"];


            //Camera on MOUSE
            lookInputAction = playerInput.actions["Look"];

            //Interaction on LeftMouseButton
            interactInputAction = playerInput.actions["Interact"];
            interactInputAction.started += OnInteractionInput;

            //Open and Close Inventory on "I"
            openInventoryAction = playerInput.actions["Inventory"];
            openInventoryAction.started += OnInventoryOpenClose;

        }

        private void GetMouseInteractor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                if(hit.transform.TryGetComponent(out ICanBePickedUp interactable))
                {
                    interactable.PickUp(inventory);
                }
            }
        }

        private void OnInteractionInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                GetMouseInteractor();
            }
        }
        private void OnInventoryOpenClose(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                inventory.EnableDisableInventory();
            }
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

