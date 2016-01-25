using UnityEngine;
using System.Collections;

public class AccelerationZone : MonoBehaviour {

    public float accelerationForce = 0.1f;
    public Vector3 direction = new Vector3(1, 0, 0);

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            direction.Normalize();
            other.attachedRigidbody.AddForce(direction * accelerationForce, ForceMode.Acceleration);
        }
    }
}
