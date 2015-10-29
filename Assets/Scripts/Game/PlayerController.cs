using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject mainCamera;
    public float drivingForce = 1f;
    public float jumpingForce = 300f;

    //private int layerMask;
    private bool isJumping = false;

    void Start()
    {
        if (mainCamera == null) mainCamera = GameObject.Find("MainCamera");
        //layerMask = (1 << LayerMask.NameToLayer("Field")) + (1 << LayerMask.NameToLayer("RealObject"));
    }

    void FixedUpdate()
    {
        Vector3 direction = transform.position - mainCamera.transform.position;
        direction.y = 0;
        direction = direction.normalized;

        GetComponent<Rigidbody>().AddForce(direction * drivingForce);

        if (Input.GetKey(KeyCode.Space) && !isJumping) GetComponent<Rigidbody>().AddForce(Vector3.up * jumpingForce);
        isJumping = true;
    }

    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint point in collision.contacts)
        {
            if (point.normal.y >= 0.5) isJumping = false;
        }
    }

    //bool IsJumping()
    //{
    //    if (Physics.Raycast(transform.position, -Vector3.up, this.GetComponent<SphereCollider>().radius, layerMask)) return false;
    //    else return true;
    //}
}
