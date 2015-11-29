using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

    public LogManager LogManager;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        if (scoreText == null) scoreText = GetComponent<Text>();
        //LogManager.SortList();
        scoreText.text = LogManager.CvtStr();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = LogManager.CvtStr();
	}
}
