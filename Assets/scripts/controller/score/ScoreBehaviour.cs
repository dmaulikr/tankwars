using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour {

    public int Score { get; set; }
    private Text ScoreText;

	// Use this for initialization
	void Start () {
        ScoreText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = "Score " + Score.ToString();
    }

    public void AddScore(int score) {
        Score += score;
    }
}
