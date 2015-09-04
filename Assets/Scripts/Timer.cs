using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeLimit = 30;

    private float timeRemaining;
    private bool timerStarted;

	// Use this for initialization
	void Start () {
        ResetTimer();
	}

    public void ResetTimer()
    {
        timeRemaining = timeLimit;
        timerStarted = false;
        Pauser.Pause();
    }

    public void StartTimer()
    {
        timerStarted = true;
        Pauser.Resume();
    }

    public void StopTimer()
    {
        timerStarted = false;
        Pauser.Pause();
    }

    public void TurnBackTime(float backTime)
    {
        timeRemaining += backTime;
    }

    public float GetRateOfTimeRemaining()
    {
        return timeRemaining / timeLimit;
    }

	// Update is called once per frame
	void Update () {
        if (timerStarted){
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                StopTimer();
            }
        }
	}
}
