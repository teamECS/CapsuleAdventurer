using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        if (player == null) player = GameObject.Find("Player");
        offset = transform.position-player.transform.position;
	}

    //void LateUpdate () {
    //}

    public void UpdateCamera()
    {
        transform.position = player.transform.position + offset;
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.RotateAround(player.transform.position, Vector3.up, 5);
        else if (Input.GetKey(KeyCode.RightArrow))   
            transform.RotateAround(player.transform.position, Vector3.up, -5);
        offset = transform.position - player.transform.position;
    }
}
