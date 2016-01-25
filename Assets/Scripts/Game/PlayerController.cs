using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject mainCamera;
    public float drivingForce = 1f;
    public float jumpingForce = 300f;
    public float maxSpeed = 10;

    private bool isGrounded = true;
    private bool isJustKeyDown = false;

    void Start()
    {
        if (mainCamera == null) mainCamera = GameObject.Find("MainCamera");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) isJustKeyDown = true;
        Debug.Log(this.GetComponent<Rigidbody>().velocity);
    }

    void FixedUpdate()
    {
        Vector3 direction = transform.position - mainCamera.transform.position;
        direction.y = 0;
        direction = direction.normalized;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (isGrounded) {
            if (rb.velocity.magnitude <= maxSpeed)
                rb.AddForce(direction * drivingForce, ForceMode.Acceleration);
            else
                rb.AddForce(direction * 5, ForceMode.Acceleration);

            if (isJustKeyDown) {
                rb.AddForce(Vector3.up * jumpingForce, ForceMode.VelocityChange);
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
