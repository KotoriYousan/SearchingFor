﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRotation : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotationSpeed = 30f;
    public float deadZoneDegrees = 15f;
    public Camera camera; 
 
    private Transform cameraT;
    private Vector3 cameraDirection;
    private Vector3 playerDirection;
    private Quaternion targetRotation;
 
    private void Awake()
    {
        cameraT = camera.transform;
    }
 
    private void Update()
    {
        cameraDirection = new Vector3(cameraT.forward.x, 0f, cameraT.forward.z);
        playerDirection = new Vector3(transform.forward.x, 0f, transform.forward.z);
 
        if(Vector3.Angle(cameraDirection, playerDirection) > deadZoneDegrees)
        {
            targetRotation = Quaternion.LookRotation(cameraDirection, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
 