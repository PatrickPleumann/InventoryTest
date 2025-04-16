using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraDirection : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float cameraPositionX = 0f;
    [SerializeField] private float cameraPositionY = 18f;
    [SerializeField] private float cameraPositionZ = -9f;

    //private void Start()
    //{
    //    transform.position = new Vector3
    //        (
    //        transform.position.x + cameraPositionX,
    //        transform.position.y + cameraPositionY,
    //        transform.position.z + cameraPositionZ
    //        );
    //}
}
