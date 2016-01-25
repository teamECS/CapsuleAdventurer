using UnityEngine;
using System.Collections;

public class TimeRateController : MonoBehaviour {

    public Timer timer;
    public FillterController fillterController;
    public float timeRate = 2.0f;

    // Use this for initialization
    void Awake()
    {
        if (timer == null) timer = GameObject.Find("Timer").GetComponent<Timer>();
        if (fillterController == null) fillterController = GameObject.Find("Fillter2").GetComponent<FillterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            timer.SetTimeRate(timeRate);
            fillterController.StartBlinking();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            timer.ResetTimeRate();
            fillterController.StopBlinking();
        }
    }
}
