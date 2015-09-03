using UnityEngine;
using System.Collections;

public class GoalZone : MonoBehaviour {

    public GameController gameController;

	// Use this for initialization
	void Start () {
        if (gameController == null) gameController = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
    void OnTriggerEnter(Collider other)
    {
        gameController.FinishGame();
    }
}
