using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

    private Timer timer;
    public float backTime = 5f;

	// Use this for initialization
	void Start () {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            timer.TurnBackTime(backTime);
        }
    }
}
