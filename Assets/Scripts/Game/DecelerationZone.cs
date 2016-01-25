using UnityEngine;
using System.Collections;

public class DecelerationZone : MonoBehaviour {

    public float decelerationRate = 0.9f;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && other.attachedRigidbody.velocity.magnitude > 3)
        {
            other.attachedRigidbody.velocity *= decelerationRate;
        }
    }
}
