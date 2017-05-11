using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour {

    private int score;
    public int Score { get; set; }
    private Text ScoreText;

	// Use this for initialization
	void Start () {
        ScoreText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = "Score " + score.ToString();
    }
}
