using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTextGenerater : MonoBehaviour {

    public GameManager gameManager;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        if(scoreText==null) scoreText = GetComponent<Text>();
        scoreText.text = "あなたのスコア：" + Mathf.Round(gameManager.GetRemainingTime() * 100);
	}
}
