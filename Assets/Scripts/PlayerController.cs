using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject mainCamera;
    public float drivingForce = 1f;
    public float jumpingForce = 300f;

    void Start()
    {
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
        int layerMaskFloor = 1 << 0;

        if (Physics.Raycast(transform.position, -Vector3.up, this.GetComponent<SphereCollider>().radius, layerMaskFloor)) return false;
        else return true;
    }
}
