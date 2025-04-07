using System;
using UnityEngine;

namespace MovementSystem
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] public float speed = 3;
        [SerializeField] public float maxSpeed = 10;
        //[SerializeField] public float jumpPower = 5;
        //[SerializeField] public float fallSpeedModifier = 1;
        //[SerializeField] public float jumpSpeedModifier = 1;

        private new Transform transform;
        private new Rigidbody rigidbody;

        private Vector3 moveDirection;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            UpdateHorizontalMovement();
        }

        public void Movement(Vector3 direction)
        {
            moveDirection = direction;
        }

        //public void Jump()
        //{

        //}

        public void RotationHorinzontal(float rotation)
        {
            var currentRotation = rigidbody.rotation.eulerAngles;
            var targetRotation = currentRotation + new Vector3(0f, rotation, 0f);

            rigidbody.rotation = Quaternion.Euler(targetRotation);
        }
        private void UpdateHorizontalMovement()
        {
            Vector3 currentVelocity = rigidbody.linearVelocity;
            Vector3 targetVelocity = new Vector3(moveDirection.x, 0f, moveDirection.z);
            targetVelocity *= speed;

            targetVelocity = transform.TransformDirection(targetVelocity);

            Vector3 velocityChange = targetVelocity - currentVelocity;
            velocityChange.y = 0f;
            velocityChange = Vector3.ClampMagnitude(velocityChange, maxSpeed);

            rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }
}

