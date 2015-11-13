using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTextGenerater : MonoBehaviour {

    public GameManager gameManager;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        if(scoreText==null) scoreText = GetComponent<Text>();
        scoreText.text = "あなたのスコア：" + gameManager.GetScore();
	}

    void Update() {
        if (gameManager.GetPlayerName() != "") scoreText.text = "「" + gameManager.GetPlayerName() + "」さんのスコア：" + gameManager.GetScore();
        else scoreText.text = "あなたのスコア：" + gameManager.GetScore();
    }
}
