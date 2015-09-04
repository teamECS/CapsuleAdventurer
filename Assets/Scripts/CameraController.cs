using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
    private Vector3 initialOffset;

    private Quaternion initialRot;
    private Vector3 initialPos;

	// Use this for initialization
	void Start () {
        initialRot = transform.rotation;
        initialPos = transform.position;

        if (player == null) player = GameObject.Find("Player");
        //offset = transform.position-player.transform.position;
        offset = new Vector3(0f, 2.5f, -3f);
        initialOffset = offset;
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

    //public void Reset()
    //{
    //    transform.rotation = initialRot;
    //    transform.position = initialPos;
    //    offset = initialOffset;
    //}
}
