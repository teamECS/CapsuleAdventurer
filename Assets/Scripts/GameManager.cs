using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private float remainingTime = 0;
    private string playerName = "";

    public void LoadScene(string sceneName)
    {
        Debug.Log("loaded " + sceneName);
        Application.LoadLevel(sceneName);
    }

    public void SetRemainingTime(float time)
    {
        remainingTime = time;
    }
    public float GetRemainingTime()
    {
        return remainingTime;
    }
    public void SetPlayerName(string name)
    {
        playerName = name;
    }
    public string GetPlayerName()
    {
        return playerName;
    }
    public float GetScore()
    {
        return Mathf.Round(remainingTime*100);
    }
}
