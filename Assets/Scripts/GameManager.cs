using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static bool isExist = false;

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

	}
	

    public void LoadScene(string sceneName)
    {
        Debug.Log("now load " + sceneName);
        Application.LoadLevel(sceneName);
    }
}
