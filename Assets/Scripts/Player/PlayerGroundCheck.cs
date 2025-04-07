using System;
using UnityEngine;

namespace MovementSystem
{
    public class PlayerGroundCheck : MonoBehaviour
    {
        public bool isActive = true;

        [Header("References")]
        [SerializeField] public PlayerController playerController;

        [Header("Settings")]
        [SerializeField] public LayerMask groundedLayerMask;

        [SerializeField] public Vector3 groundCheckPosition;
        [SerializeField] public Vector3 groundCheckSize;

        [Header ("Raycast")]
        [SerializeField] public Transform rayCastOrigin;
 
        public bool IsGrounded { get; private set; }

        private new Transform transform;

        private void Awake()
        {
            transform = GetComponent<Transform>();
        }

        private void Update()
        {
            if (isActive == true)
            {
                CheckForGround();
            }
           
        }

        private void CheckForGround()
        {
            IsGrounded = Physics.OverlapBox(transform.position + groundCheckPosition,
                groundCheckSize / 2, Quaternion.identity, groundedLayerMask).Length > 0;
        }

        private void OnDrawGizmos()
        {
            transform = GetComponent<Transform>();

            Gizmos.DrawCube(transform.position + groundCheckPosition, groundCheckSize);
            Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.forward * 2, Color.cyan);

        }
    }
}

