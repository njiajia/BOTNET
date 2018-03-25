using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

	public int scoreInt = 0;
	public Text score;
	
	// Update is called once per frame
	void Update () {
		score.text = ("SCORE: " + scoreInt);
		PlayerPrefs.SetInt("scoreInt", scoreInt);
	}

	public void scoreUp(){
		scoreInt += 10;
	}
}
