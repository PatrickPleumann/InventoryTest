using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace MovementSystem
{
    public class PlayerController : MonoBehaviour, IPointerClickHandler
    {
        [Header("Movement")]
        [SerializeField] public PlayerMovement playerMovement;

        [Header("Interaction")]
        [SerializeField] public ClosestTargetProvider interactableProvider;
        [SerializeField] public Inventory inventory; // neu

        [Header("Input")]
        [SerializeField] public PlayerInput playerInput;

        [Header("Camera Settings")]
        [SerializeField] public Transform cameraTransform;
        [SerializeField] public float lookSensitivity;

        private InputAction moveInputAction;
        private InputAction lookInputAction;
        private InputAction interactInputAction;
        private InputAction openInventoryAction;
        

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
            //interactInputAction = playerInput.actions["Interact"];
            //interactInputAction. += OnPointerClick;

            openInventoryAction = playerInput.actions["Inventory"];
            openInventoryAction.started += OnInventoryOpenClose;


        }



        private void OnInteractionInput(PointerEventData eventData)
        {

            
            //var closestInteractable = interactableProvider.GetTarget<IAmInteractable>();
            //if (closestInteractable == false)
            //{
            //    return;
            //}
            //closestInteractable.Interact();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            eventData.pointerClick.TryGetComponent<IAmInteractable>(out IAmInteractable context);
            context.Interact(inventory.transform);
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

        private void OnInventoryOpenClose(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                inventory.EnableDisableInventory();
            }
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

