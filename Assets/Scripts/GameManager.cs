using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static bool isExist = false;
    private float remainingTime;

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
        Debug.Log("now loaded " + sceneName);
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
}
