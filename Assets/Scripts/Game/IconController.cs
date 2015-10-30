using UnityEngine;
using System.Collections;

public class IconController : MonoBehaviour {

    public GameObject target;
    public float yPos = 100f;

	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(target.transform.position.x, yPos, target.transform.position.z);
	}
}
