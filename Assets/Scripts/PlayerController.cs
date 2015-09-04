﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject mainCamera;
    public float drivingForce = 1f;
    public float jumpingForce = 300f;

    private Quaternion initialRot;
    private Vector3 initialPos;

    void Start()
    {
        initialRot = transform.rotation;
        initialPos = transform.position;

        if(mainCamera == null) mainCamera = GameObject.Find("MainCamera");
    }

    void FixedUpdate()
    {
        Vector3 direction = transform.position - mainCamera.transform.position;
        direction.y = 0;
        direction = direction.normalized;

        GetComponent<Rigidbody>().AddForce(direction * drivingForce);

        if (Input.GetKey(KeyCode.Space) && !IsJumping()) GetComponent<Rigidbody>().AddForce(Vector3.up * jumpingForce);
    }

    bool IsJumping()
    {
        int layerMaskFloor = 1 << 8;

        if (Physics.Raycast(transform.position, -Vector3.up, this.GetComponent<SphereCollider>().radius, layerMaskFloor)) return false;
        else return true;
    }

    //public void Reset()
    //{
    //    transform.rotation = initialRot;
    //    transform.position = initialPos;
    //    GetComponent<Rigidbody>().velocity = Vector3.zero;
    //    GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    //}
}
