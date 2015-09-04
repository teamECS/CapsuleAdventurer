using UnityEngine;
using System.Collections;

public class IconController : MonoBehaviour {

    public GameObject target;

	// Update is called once per frame
	void Update () {
        transform.position = target.transform.position;
	}
}
