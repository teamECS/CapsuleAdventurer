using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject mainCamera;
    public float drivingForce = 1f;
    public float jumpingForce = 300f;

    private bool isGrounded = true;
    private bool isJustKeyDown = false;

    void Start()
    {
        if (mainCamera == null) mainCamera = GameObject.Find("MainCamera");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) isJustKeyDown = true;
    }

    void FixedUpdate()
    {
        Vector3 direction = transform.position - mainCamera.transform.position;
        direction.y = 0;
        direction = direction.normalized;

        if (isGrounded) {
            GetComponent<Rigidbody>().AddForce(direction * drivingForce);

            if (isJustKeyDown) {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpingForce);
                isGrounded = false;
            }
        }
        isJustKeyDown = false;
    }

    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint point in collision.contacts)
        {
            if (point.normal.y > 0) isGrounded = true;
            //if (point.normal.y > 0 && this.GetComponent<Rigidbody>().velocity.y <= 1) isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
