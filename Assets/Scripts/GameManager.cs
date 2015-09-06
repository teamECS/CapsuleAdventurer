using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static bool isExist = false;
    private float remainingTime;
    private string playerName;

    void Awake(){
        if (!isExist)
        {
            DontDestroyOnLoad(this.gameObject);
            isExist = true;
        }
        else Destroy(this.gameObject);
    }

	// Use this for initialization
	void Start () {
        remainingTime = 0;
	}
	

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
}
