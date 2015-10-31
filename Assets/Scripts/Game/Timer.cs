using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeLimit = 30;

    private float remainingTime;
    private bool timerStarted;

	// Use this for initialization
	void Start () {
        ResetTimer();
	}

    public void ResetTimer()
    {
        remainingTime = timeLimit;
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
        remainingTime += backTime;
        if (remainingTime > timeLimit) remainingTime = timeLimit;
    }

    public float GetRateOfRemainingTime()
    {
        return remainingTime / timeLimit;
    }
    public float GetRemainingTime()
    {
        return remainingTime;
    }

	// Update is called once per frame
	void Update () {
        if (timerStarted){
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                remainingTime = 0;
                StopTimer();
            }
        }
	}
}
