using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeLimit = 30;

    private float remainingTime;
    private bool timerStarted;

	// Use this for initialization
	void Start () {
        StopTimer();
        ResetTimer();
	}

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                StopTimer();
                remainingTime = 0;
            }
        }
    }


    public void StartTimer()
    {
        timerStarted = true;
        //Pauser.Resume();
        Time.timeScale = 1;
    }
    public void StopTimer()
    {
        timerStarted = false;
        //Pauser.Pause();
        Time.timeScale = 0;
    }
    public void ResetTimer()
    {
        remainingTime = timeLimit;
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
}
